// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/operation"
	"strings"

	"github.com/go-openapi/spec"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/commonschema"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (d *SwaggerDefinition) parseResourcesWithinSwaggerTag(tag *string, resourceProvider *string, resourceIds resourceids.ParseResult) (*sdkModels.APIResource, error) {
	result := parserModels.ParseResult{
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

	// pull out each of the remaining models based on what we've got
	nestedResult, err = d.findNestedItemsYetToBeParsed(*operations, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	}

	// then pull out the embedded model for List operations (e.g. we don't want the wrapper type but the type for the `value` field)
	operations, err = operation.RemoveWrapperModelForListOperations(*operations, result)
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

	// then switch out any Common Schema Types (e.g. Identity)
	resource = commonschema.ReplaceSDKObjectDefinitionsAsNeeded(resource)

	// first Normalize the names, meaning `foo` -> `Foo` for consistency
	resource = cleanup.NormalizeAPIResource(resource)

	return &resource, nil
}

func (d *SwaggerDefinition) findNestedItemsYetToBeParsed(operations map[string]sdkModels.SDKOperation, known parserModels.ParseResult) (*parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
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

func (d *SwaggerDefinition) determineObjectsRequiredButNotParsed(operations map[string]sdkModels.SDKOperation, known parserModels.ParseResult) (*[]string, error) {
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
			topLevelRef := sdkHelpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
			if topLevelRef.Type == sdkModels.ReferenceSDKObjectDefinitionType {
				isKnownConstant, isKnownModel := known.IsObjectKnown(*topLevelRef.ReferenceName)
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
			topLevelRef := sdkHelpers.InnerMostSDKObjectDefinition(*operation.ResponseObject)
			if topLevelRef.Type == sdkModels.ReferenceSDKObjectDefinitionType {
				isKnownConstant, isKnownModel := known.IsObjectKnown(*topLevelRef.ReferenceName)
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
			topLevelRef := sdkHelpers.InnerMostSDKOperationOptionObjectDefinition(value.ObjectDefinition)
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
		definition := sdkHelpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
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
