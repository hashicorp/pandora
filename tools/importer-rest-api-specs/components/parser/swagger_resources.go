// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"net/http"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/commonschema"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (d *SwaggerDefinition) parseResourcesWithinSwaggerTag(tag *string, resourceProvider *string, resourceIds resourceids.ParseResult) (*sdkModels.APIResource, error) {
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	// note that Resource ID's can contain Constants (used as segments)
	if err := result.AppendConstants(resourceIds.Constants); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Constants: %+v", err)
	}

	// pull out the operations and any inlined/top-level constants/models
	operations, nestedResult, err := d.parseOperationsWithinTag(tag, resourceIds.OperationIdsToParsedResourceIds, resourceProvider, result)
	if err != nil {
		return nil, fmt.Errorf("finding operations: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Operations: %+v", err)
	}

	// pull out all of the remaining models based on what we've got
	nestedResult, err = d.findNestedItemsYetToBeParsed(*operations, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	}

	// then pull out the embedded model for List operations (e.g. we don't want the wrapper type but the type for the `value` field)
	operations, err = pullOutModelForListOperations(*operations, result)
	if err != nil {
		return nil, fmt.Errorf("pulling out model from list operations: %+v", err)
	}

	// if there's nothing here, there's no point generating a package
	if len(*operations) == 0 {
		return nil, nil
	}

	resource := sdkModels.APIResource{
		Constants:   result.Constants,
		Models:      result.Models,
		Operations:  *operations,
		ResourceIDs: resourceIds.NamesToResourceIDs,
	}

	// then switch out any custom types (e.g. Identity)
	resource = switchOutCustomTypesAsNeeded(resource)

	// first Normalize the names, meaning `foo` -> `Foo` for consistency
	resource = cleanup.NormalizeAPIResource(resource)

	return &resource, nil
}

type listOperationDetails struct {
	fieldContainingPaginationDetails *string
	valueObjectDefinition            *sdkModels.SDKObjectDefinition
}

func listOperationDetailsForOperation(input sdkModels.SDKOperation, known internal.ParseResult) *listOperationDetails {
	if !strings.EqualFold(input.Method, http.MethodGet) && !strings.EqualFold(input.Method, http.MethodPost) {
		return nil
	}

	// an operation without a response object isn't going to be listable
	if input.ResponseObject == nil {
		return nil
	}
	if input.ResponseObject.Type == sdkModels.ReferenceSDKObjectDefinitionType {
		responseModel, isModel := known.Models[*input.ResponseObject.ReferenceName]
		if !isModel {
			// a constant wouldn't be listable
			return nil
		}

		out := listOperationDetails{}
		if input.FieldContainingPaginationDetails != nil {
			out.fieldContainingPaginationDetails = input.FieldContainingPaginationDetails
		}
		for fieldName, v := range responseModel.Fields {
			if strings.EqualFold(fieldName, "nextLink") {
				out.fieldContainingPaginationDetails = pointer.To(fieldName)
				continue
			}

			if strings.EqualFold(fieldName, "Value") {
				// switch out the reference to be the SDKObjectDefinition for the `Value` field, rather than
				// the wrapper type
				definition := helpers.InnerMostSDKObjectDefinition(v.ObjectDefinition)
				out.valueObjectDefinition = pointer.To(definition)
				continue
			}
		}
		if out.fieldContainingPaginationDetails != nil && out.valueObjectDefinition != nil {
			return &out
		}
	}

	return nil
}

func pullOutModelForListOperations(input map[string]sdkModels.SDKOperation, known internal.ParseResult) (*map[string]sdkModels.SDKOperation, error) {
	// List Operations return an object which contains a NextLink and a Value (which is the actual Object
	// being paginated on) - so we want to replace the wrapper object with the Value so that these can be
	// paginated correctly as needed.
	output := make(map[string]sdkModels.SDKOperation)

	for operationName := range input {
		operation := input[operationName]

		// if the Response Object is a List Operation (identifiable via
		listDetails := listOperationDetailsForOperation(operation, known)
		if listDetails != nil {
			operation.FieldContainingPaginationDetails = listDetails.fieldContainingPaginationDetails
			operation.ResponseObject = listDetails.valueObjectDefinition
		}

		output[operationName] = operation
	}

	return &output, nil
}

func switchOutCustomTypesAsNeeded(input sdkModels.APIResource) sdkModels.APIResource {
	output := input
	for modelName, model := range input.Models {
		fields := model.Fields
		for fieldName := range model.Fields {
			field := model.Fields[fieldName]

			// switch out the Object Definition for this field if needed
			for _, matcher := range commonschema.Matchers {
				if matcher.IsMatch(field, input) {
					field.ObjectDefinition = matcher.ReplacementObjectDefinition()
					break
				}
			}

			fields[fieldName] = field
		}
		model.Fields = fields
		output.Models[modelName] = model
	}

	return output
}

func (d *SwaggerDefinition) findNestedItemsYetToBeParsed(operations map[string]sdkModels.SDKOperation, known internal.ParseResult) (*internal.ParseResult, error) {
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	// Now that we have a complete list of all of the nested items to find, loop around and find them
	// this is intentionally not fetching nested models to avoid an infinite loop with Model1 referencing
	// Model2 which references Model1 (they instead get picked up in the next iteration)
	referencesToFind, err := d.determineObjectsRequiredButNotParsed(operations, result)
	if err != nil {
		return nil, fmt.Errorf("determining objects required but not parsed: %+v", err)
	}
	for len(*referencesToFind) > 0 {
		for _, referenceName := range *referencesToFind {
			topLevelObject, err := d.findTopLevelObject(referenceName)
			if err != nil {
				return nil, fmt.Errorf("finding top level object named %q: %+v", referenceName, err)
			}

			parsedAsAConstant, constErr := constants.Parse(topLevelObject.Type, referenceName, nil, topLevelObject.Enum, topLevelObject.Extensions)
			parsedAsAModel, modelErr := d.parseModel(referenceName, *topLevelObject)
			if (constErr != nil && modelErr != nil) || (parsedAsAConstant == nil && parsedAsAModel == nil) {
				return nil, fmt.Errorf("reference %q didn't parse as a Model or a Constant.\n\nConstant Error: %+v\n\nModel Error: %+v", referenceName, constErr, modelErr)
			}

			if parsedAsAConstant != nil {
				result.Constants[parsedAsAConstant.Name] = parsedAsAConstant.Details
			}
			if parsedAsAModel != nil {
				if err := result.Append(*parsedAsAModel); err != nil {
					return nil, fmt.Errorf("appending model: %+v", err)
				}
			}
		}

		remainingReferencesToFind, err := d.determineObjectsRequiredButNotParsed(operations, result)
		if err != nil {
			return nil, fmt.Errorf("determining objects required but not parsed: %+v", err)
		}
		if referencesAreTheSame(*referencesToFind, *remainingReferencesToFind) {
			return nil, fmt.Errorf("the following references couldn't be found: %q", strings.Join(*referencesToFind, ", "))
		}
		referencesToFind = remainingReferencesToFind
	}

	return &result, nil
}

func referencesAreTheSame(first []string, second []string) bool {
	if len(first) != len(second) {
		return false
	}

	// first load the existing keys
	keys := make(map[string]struct{}, 0)
	for _, key := range first {
		keys[key] = struct{}{}
	}

	// then check the remaining ones
	for _, key := range second {
		if _, exists := keys[key]; !exists {
			return false
		}
	}

	return true
}

func (d *SwaggerDefinition) determineObjectsRequiredButNotParsed(operations map[string]sdkModels.SDKOperation, known internal.ParseResult) (*[]string, error) {
	referencesToFind := make(map[string]struct{}, 0)

	var objectsRequiredByModel = func(modelName string, model sdkModels.SDKModel) (*[]string, error) {
		result := make(map[string]struct{}, 0)
		// if it's a model, we need to check all of the fields for this to find any constant or models
		// that we don't know about
		typesToFind, err := d.objectsUsedByModel(modelName, model)
		if err != nil {
			return nil, fmt.Errorf("determining objects used by model %q: %+v", modelName, err)
		}
		for _, typeName := range *typesToFind {
			_, existingConstant := known.Constants[typeName]
			_, existingModel := known.Models[typeName]
			if !existingConstant && !existingModel {
				result[typeName] = struct{}{}
			}
		}

		out := make([]string, 0)
		for k := range result {
			out = append(out, k)
		}
		return &out, nil
	}

	for _, operation := range operations {
		if operation.RequestObject != nil {
			topLevelRef := helpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
			if topLevelRef.Type == sdkModels.ReferenceSDKObjectDefinitionType {
				isKnownConstant, isKnownModel := isObjectKnown(*topLevelRef.ReferenceName, known)
				if !isKnownConstant && !isKnownModel {
					referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
				}

				if isKnownModel {
					modelName := *topLevelRef.ReferenceName
					model := known.Models[modelName]
					missingReferencesInModel, err := objectsRequiredByModel(modelName, model)
					if err != nil {
						return nil, fmt.Errorf("determining objects required by model %q: %+v", modelName, err)
					}
					for _, name := range *missingReferencesInModel {
						referencesToFind[name] = struct{}{}
					}
				}
			}
		}

		if operation.ResponseObject != nil {
			topLevelRef := helpers.InnerMostSDKObjectDefinition(*operation.ResponseObject)
			if topLevelRef.Type == sdkModels.ReferenceSDKObjectDefinitionType {
				isKnownConstant, isKnownModel := isObjectKnown(*topLevelRef.ReferenceName, known)
				if !isKnownConstant && !isKnownModel {
					referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
				}

				if isKnownModel {
					// if it's a model, we need to check all of the fields for this to find any constant or models
					// that we don't know about
					modelName := *topLevelRef.ReferenceName
					model := known.Models[modelName]
					missingReferencesInModel, err := objectsRequiredByModel(modelName, model)
					if err != nil {
						return nil, fmt.Errorf("determining objects required by model %q: %+v", modelName, err)
					}
					for _, name := range *missingReferencesInModel {
						referencesToFind[name] = struct{}{}
					}
				}
			}
		}

		for _, value := range operation.Options {
			topLevelRef := topLevelOptionsObjectDefinition(value.ObjectDefinition)
			if topLevelRef.Type != sdkModels.ReferenceSDKOperationOptionObjectDefinitionType {
				continue
			}

			if _, isKnown := known.Constants[*topLevelRef.ReferenceName]; !isKnown {
				referencesToFind[*topLevelRef.ReferenceName] = struct{}{}
			}
		}
	}

	// then verify we have all of the models for the current models we know about
	for modelName, model := range known.Models {
		missingReferencesInModel, err := objectsRequiredByModel(modelName, model)
		if err != nil {
			return nil, fmt.Errorf("determining objects required by model %q: %+v", modelName, err)
		}
		for _, name := range *missingReferencesInModel {
			referencesToFind[name] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range referencesToFind {
		if _, exists := known.Constants[k]; exists {
			continue
		}
		if _, exists := known.Models[k]; exists {
			continue
		}

		out = append(out, k)
	}

	return &out, nil
}

func (d *SwaggerDefinition) objectsUsedByModel(modelName string, model sdkModels.SDKModel) (*[]string, error) {
	typeNames := make(map[string]struct{}, 0)

	for _, field := range model.Fields {
		definition := helpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
		if definition.ReferenceName != nil {
			typeNames[*definition.ReferenceName] = struct{}{}
		}
	}

	if model.ParentTypeName != nil {
		typeNames[*model.ParentTypeName] = struct{}{}
	}

	if model.FieldNameContainingDiscriminatedValue != nil {
		// this must be a discriminator
		modelNamesThatImplementThis, err := d.findModelNamesWhichImplement(modelName)
		if err != nil {
			return nil, fmt.Errorf("finding models which implement %q: %+v", modelName, err)
		}
		for _, k := range *modelNamesThatImplementThis {
			typeNames[k] = struct{}{}
		}
	}

	out := make([]string, 0)
	for k := range typeNames {
		out = append(out, k)
	}
	return &out, nil
}

func (d *SwaggerDefinition) findModelNamesWhichImplement(parentName string) (*[]string, error) {
	modelNames := make([]string, 0)

	for childName, value := range d.swaggerSpecExtendedRaw.Definitions {
		implementsParent, err := d.doesModelImplement(childName, value, parentName)
		if err != nil {
			return nil, fmt.Errorf("determining if model %q implements %q: %+v", childName, parentName, err)
		}
		if !*implementsParent {
			continue
		}

		logging.Tracef("Found %q implements %q", childName, parentName)
		modelNames = append(modelNames, childName)
	}

	return &modelNames, nil
}

func (d *SwaggerDefinition) doesModelImplement(modelName string, value spec.Schema, parentName string) (*bool, error) {
	implementsParent := false
	if !strings.EqualFold(modelName, parentName) {
		// does it implement (AllOf) the base class
		for _, parent := range value.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			if strings.EqualFold(*fragmentName, parentName) {
				implementsParent = true
				break
			}

			// otherwise does this model inherit from a model which does?
			item, err := d.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("loading Parent %q: %+v", *fragmentName, err)
			}
			if len(item.AllOf) > 0 {
				inheritsFromParent, err := d.doesModelImplement(*fragmentName, *item, parentName)
				if err != nil {
					return nil, fmt.Errorf("determining if model %q implements %q: %+v", *fragmentName, parentName, err)
				}
				if *inheritsFromParent {
					implementsParent = true
					break
				}
			}
		}
	}

	return &implementsParent, nil
}

func isObjectKnown(name string, known internal.ParseResult) (bool, bool) {
	_, isConstant := known.Constants[name]
	_, isModel := known.Models[name]
	return isConstant, isModel
}
