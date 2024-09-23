// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/constants"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (d *SwaggerDefinition) parseModel(name string, input spec.Schema) (*internal.ParseResult, error) {
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	// 1. find any constants used within this model
	nestedResult, err := d.findConstantsWithinModel(name, nil, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding constants within model: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from constants: %+v", err)
	}

	// 2. iterate over the fields and find all of the fields for this model
	fields, nestedResult, err := d.fieldsForModel(name, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding fields for model: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from fields: %+v", err)
	}

	// if it's just got constants, we can skip it
	if len(*fields) == 0 {
		return &result, nil
	}

	// 3. finally build this model directly
	// Notably, we **DO NOT** load models used by this models here - this is handled once we
	// know all the models which we want to load - to avoid infinite loops
	model, err := d.modelDetailsFromObject(name, input, *fields)
	if err != nil {
		return nil, fmt.Errorf("populating model details for %q: %+v", name, err)
	}
	result.Models[name] = *model

	return &result, nil
}

func (d *SwaggerDefinition) findConstantsWithinModel(fieldName string, modelName *string, input spec.Schema, known internal.ParseResult) (*internal.ParseResult, error) {
	// NOTE: both Models and Fields are passed in here
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	if len(input.Enum) > 0 {
		constant, err := constants.MapConstant(input.Type, fieldName, modelName, input.Enum, input.Extensions)
		if err != nil {
			return nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.Constants[constant.Name] = constant.Details
	}

	// Check any object that this model inherits from
	if len(input.AllOf) > 0 {
		for _, parent := range input.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			// have we already obtained this model, if so skip it
			if _, alreadyParsedModel := result.Models[*fragmentName]; alreadyParsedModel {
				continue
			}

			topLevelModel, err := d.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("finding top level model %q for constants: %+v", *fragmentName, err)
			}

			nestedResult, err := d.findConstantsWithinModel(*fragmentName, &fieldName, *topLevelModel, result)
			if err != nil {
				return nil, fmt.Errorf("finding constants within parent model %q: %+v", *fragmentName, err)
			}

			if err := result.Append(*nestedResult); err != nil {
				return nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}
	}

	for propName, propVal := range input.Properties {
		logging.Tracef("Processing Property %q..", propName)
		// models can contain nested models - either can contain constants, so around we go..
		nestedResult, err := d.findConstantsWithinModel(propName, &fieldName, propVal, result)
		if err != nil {
			return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
		}
		if err := result.Append(*nestedResult); err != nil {
			return nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
	}

	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		for propName, propVal := range input.AdditionalProperties.Schema.Properties {
			logging.Tracef("Processing Additional Property %q..", propName)
			// models can contain nested models - either can contain constants, so around we go..
			nestedConstants, err := d.findConstantsWithinModel(propName, &fieldName, propVal, result)
			if err != nil {
				return nil, fmt.Errorf("finding nested constants within %q: %+v", propName, err)
			}

			if err := result.Append(*nestedConstants); err != nil {
				return nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}
	}

	return &result, nil
}

func (d *SwaggerDefinition) detailsForField(modelName string, propertyName string, value spec.Schema, isRequired bool, known internal.ParseResult) (*sdkModels.SDKField, *internal.ParseResult, error) {
	logging.Tracef("Parsing details for field %q in %q..", propertyName, modelName)

	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	field := sdkModels.SDKField{
		Required:  isRequired,
		Optional:  !isRequired, //TODO: re-enable readonly && !value.ReadOnly,
		ReadOnly:  false,       // TODO: re-enable readonly value.ReadOnly,
		Sensitive: false,       // todo: this probably needs to be a predefined list, unless there's something we can parse
		JsonName:  propertyName,
		//Description: value.Description, // TODO: currently causes flapping diff in api definitions, see https://github.com/hashicorp/pandora/issues/3325
	}

	// first get the object definition
	parsingModel := false
	objectDefinition, nestedResult, err := d.parseObjectDefinition(modelName, propertyName, &value, result, parsingModel)
	if err != nil {
		return nil, nil, fmt.Errorf("parsing object definition: %+v", err)
	}
	if nestedResult != nil {
		result.Append(*nestedResult)
	}

	// TODO: support for other date formats (RFC3339Nano etc)
	// https://github.com/hashicorp/pandora/issues/8
	if objectDefinition.Type == sdkModels.DateTimeSDKObjectDefinitionType {
		field.DateFormat = pointer.To(sdkModels.RFC3339SDKDateFormat)
	}

	// if there are more than 1 allOf, it can not use a simple reference type, but a new definition
	if len(value.Properties) > 0 || len(value.AllOf) > 1 {
		// there's a nested model we need to pull out
		inlinedName := inlinedModelName(modelName, propertyName)
		nestedFields := make(map[string]sdkModels.SDKField, 0)
		for propName, propVal := range value.Properties {
			nestedFieldRequired := false
			for _, field := range value.Required {
				if strings.EqualFold(field, propName) {
					nestedFieldRequired = true
					break
				}
			}
			nestedField, nestedResult, err := d.detailsForField(inlinedName, propName, propVal, nestedFieldRequired, result)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing inlined model %q: %+v", inlinedName, err)
			}
			if err := result.Append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
			nestedFields[propName] = *nestedField
		}
		for _, inlinedModel := range value.AllOf {
			remoteRef := fragmentNameFromReference(inlinedModel.Ref)
			if remoteRef == nil {
				// it's possible for the AllOf to just be a description (or contain a Type)
				continue
			}

			remoteSpec, err := d.findTopLevelObject(*remoteRef)
			if err != nil {
				return nil, nil, fmt.Errorf("could not find allOf referenced model %q", *remoteRef)
			}

			for propName, propVal := range remoteSpec.Properties {
				nestedFieldRequired := false
				for _, field := range value.Required {
					if strings.EqualFold(field, propName) {
						nestedFieldRequired = true
						break
					}
				}
				nestedField, nestedResult, err := d.detailsForField(inlinedName, propName, propVal, nestedFieldRequired, result)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing inlined model %q: %+v", inlinedName, err)
				}
				if err := result.Append(*nestedResult); err != nil {
					return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
				}
				nestedFields[propName] = *nestedField
			}
		}

		inlinedModelDetails, err := d.modelDetailsFromObject(inlinedName, value, nestedFields)
		if err != nil {
			return nil, nil, fmt.Errorf("building model details for inlined model %q: %+v", inlinedName, err)
		}
		result.Models[inlinedName] = *inlinedModelDetails
		// then swap out the reference
		objectDefinition.Type = sdkModels.ReferenceSDKObjectDefinitionType
		objectDefinition.ReferenceName = &inlinedName
	}

	// Custom Types are determined once all the models/constants have been pulled out at the end
	// so just assign this for now
	field.ObjectDefinition = *objectDefinition

	return &field, &result, err
}

func (d *SwaggerDefinition) fieldsForModel(modelName string, input spec.Schema, known internal.ParseResult) (*map[string]sdkModels.SDKField, *internal.ParseResult, error) {
	fields := make(map[string]sdkModels.SDKField, 0)
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	requiredFields := make(map[string]struct{}, 0)
	for _, k := range input.Required {
		requiredFields[k] = struct{}{}
	}

	// models can inherit from other models, so let's get all of the parent fields here
	for i, parent := range input.AllOf {
		fragmentName := fragmentNameFromReference(parent.Ref)
		if fragmentName == nil {
			// sometimes this is bad data rather than a reference, so it should be skipped, example:
			//  > "allOf": [
			//  >   {
			//  >     "$ref": "#/definitions/AccessReviewDecisionIdentity"
			//  >   },
			//  >   {
			//  >     "type": "object",
			//  >     "description": "AccessReviewDecisionUserIdentity"
			//  >   }
			//  > ],

			// however sometimes these contain actual properties and should be parsed out:
			// > "allOf": [
			// >  {
			// >    "$ref": "#/definitions/DigitalTwinsEndpointResourceProperties"
			// >      },
			// >      {
			// >        "type": "object",
			// >        "properties": {
			// >          "TopicEndpoint": {
			// >            "description": "EventGrid Topic Endpoint",
			// >            "type": "string"
			// >          },
			// >          "accessKey1": {
			// >            "x-ms-secret": true,
			// >            "description": "EventGrid secondary accesskey. Will be obfuscated during read.",
			// >            "type": "string",
			// >          "x-nullable": true
			// >         },
			// >         "accessKey2": {
			// >           "x-ms-secret": true,
			// >           "description": "EventGrid secondary accesskey. Will be obfuscated during read.",
			// >           "type": "string",
			// >           "x-nullable": true
			// >         }
			// >       }
			// >     }
			// >   ]
			// > },

			if parent.Type.Contains("object") {
				innerModelName := modelName
				if parent.Title != "" {
					innerModelName = parent.Title
				}
				parsedParent, nestedResult, err := d.fieldsForModel(innerModelName, parent, known)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing fields within allOf model %q (index %d): %+v", innerModelName, i, err)
				}
				if nestedResult != nil {
					if err := result.Append(*nestedResult); err != nil {
						return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
					}
				}
				if parsedParent != nil {
					for k, v := range *parsedParent {
						fields[k] = v
					}
				}
			}

			continue
		}

		topLevelObject, err := d.findTopLevelObject(*fragmentName)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing top level object %q: %+v", *fragmentName, err)
		}
		for _, k := range topLevelObject.Required {
			requiredFields[k] = struct{}{}
		}

		nestedFields, nestedResult, err := d.fieldsForModel(*fragmentName, *topLevelObject, result)
		if err != nil {
			return nil, nil, fmt.Errorf("finding fields for parent model %q: %+v", *fragmentName, err)
		}
		for k, v := range *nestedFields {
			isRequired := isFieldRequired(k, requiredFields)
			v.Required = isRequired
			fields[k] = v
		}
		if nestedResult != nil {
			result.Append(*nestedResult)
		}
	}

	// then we get the simple thing of iterating over these fields
	for propName, propVal := range input.Properties {
		isRequired := isFieldRequired(propName, requiredFields)
		field, nestedResult, err := d.detailsForField(modelName, propName, propVal, isRequired, result)
		if err != nil {
			return nil, nil, fmt.Errorf("mapping field %q for %q: %+v", propName, modelName, err)
		}
		if nestedResult != nil {
			if err := result.Append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}

		// whilst we could look to normalize the name we're intentionally not doing so here
		fields[propName] = *field
	}

	return &fields, &result, nil
}

func (d *SwaggerDefinition) findTopLevelObject(name string) (*spec.Schema, error) {
	for modelName, model := range d.swaggerSpecRaw.Definitions {
		if strings.EqualFold(modelName, name) {
			return &model, nil
		}
	}

	for modelName, model := range d.swaggerSpecExtendedRaw.Definitions {
		if strings.EqualFold(modelName, name) {
			return &model, nil
		}
	}

	return nil, fmt.Errorf("the top level object %q was not found", name)
}

func (d *SwaggerDefinition) modelDetailsFromObject(modelName string, input spec.Schema, fields map[string]sdkModels.SDKField) (*sdkModels.SDKModel, error) {
	details := sdkModels.SDKModel{
		Fields: fields,
	}

	// if this is a Parent
	if input.Discriminator != "" {
		details.FieldNameContainingDiscriminatedValue = &input.Discriminator

		// check that there's at least one implementation of this type - otherwise this this isn't a discriminated type
		// but bad data we should ignore
		implementations, err := d.findModelNamesWhichImplement(modelName)
		if err != nil {
			return nil, fmt.Errorf("finding models which implement %q: %+v", modelName, err)
		}
		hasAtLeastOneImplementation := len(*implementations) > 0
		if !hasAtLeastOneImplementation {
			details.FieldNameContainingDiscriminatedValue = nil
		}
	}

	// this would be an Implementation
	if v, ok := input.Extensions.GetString("x-ms-discriminator-value"); ok {
		details.DiscriminatedValue = &v

		// so we need to find the ancestor details
		parentTypeName, discriminator, err := d.findAncestorType(input)
		if err != nil {
			return nil, fmt.Errorf("finding ancestor type for %q: %+v", modelName, err)
		}
		if parentTypeName != nil && discriminator != nil {
			details.ParentTypeName = parentTypeName
			details.FieldNameContainingDiscriminatedValue = discriminator
		}

		// however if there's a Discriminator value defined but no parent type - this is bad data - so we should ignore it
		if details.ParentTypeName == nil || details.FieldNameContainingDiscriminatedValue == nil {
			details.DiscriminatedValue = nil
		}
	}

	return &details, nil
}

func (d *SwaggerDefinition) findAncestorType(input spec.Schema) (*string, *string, error) {
	for _, parentRaw := range input.AllOf {
		parentFragmentName := fragmentNameFromReference(parentRaw.Ref)
		if parentFragmentName == nil {
			continue
		}

		parent, err := d.findTopLevelObject(*parentFragmentName)
		if err != nil {
			return nil, nil, fmt.Errorf("finding top level object %q: %+v", *parentFragmentName, err)
		}

		if parent.Discriminator != "" {
			return parentFragmentName, &parent.Discriminator, nil
		}

		// does the parent itself inherit from something?
		if len(parent.AllOf) == 0 {
			continue
		}

		parentTypeName, discriminator, err := d.findAncestorType(*parent)
		if err != nil {
			return nil, nil, fmt.Errorf("finding ancestor type for %q: %+v", *parentFragmentName, err)
		}
		if parentTypeName != nil && discriminator != nil {
			return parentTypeName, discriminator, nil
		}
	}
	return nil, nil, nil
}

func (d *SwaggerDefinition) findOrphanedDiscriminatedModels(serviceName string) (*internal.ParseResult, error) {
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	for modelName, definition := range d.swaggerSpecRaw.Definitions {
		if _, ok := definition.Extensions.GetString("x-ms-discriminator-value"); ok {
			details, err := d.parseModel(modelName, definition)
			if err != nil {
				return nil, fmt.Errorf("parsing model details for model %q: %+v", modelName, err)
			}
			if err := result.Append(*details); err != nil {
				return nil, fmt.Errorf("appending model %q: %+v", modelName, err)
			}
		}

		// intentionally scoped to `datafactory` given the peculiarities in the swagger definition
		// in particular question 4. in this issue https://github.com/Azure/azure-rest-api-specs/issues/28380
		if strings.EqualFold(serviceName, "datafactory") {
			// this catches orphaned discriminated models where the discriminator information is housed in the parent
			// and uses the name of the model as the discriminated value
			if _, ok := definition.Extensions.GetString("x-ms-discriminator-value"); !ok && len(definition.AllOf) > 0 {
				parentType, discriminator, err := d.findAncestorType(definition)
				if err != nil {
					return nil, fmt.Errorf("determining ancestor type for model %q: %+v", modelName, err)
				}

				details, err := d.parseModel(modelName, definition)
				if err != nil {
					return nil, fmt.Errorf("parsing model details for model %q: %+v", modelName, err)
				}
				if parentType != nil && discriminator != nil {
					model := details.Models[modelName]
					model.ParentTypeName = parentType
					model.FieldNameContainingDiscriminatedValue = discriminator
					model.DiscriminatedValue = pointer.To(modelName)
					details.Models[modelName] = model
				}
				if err := result.Append(*details); err != nil {
					return nil, fmt.Errorf("appending model %q: %+v", modelName, err)
				}
			}
		}
	}

	// this will also pull out the parent model in the file which will already have been parsed, but that's ok
	// since they will be de-duplicated when we call combineResourcesWith
	nestedResult, err := d.findNestedItemsYetToBeParsed(map[string]sdkModels.SDKOperation{}, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	}

	return &result, nil
}

// if `inputForModel` is false, it means the `input` schema cannot be used to parse the model of `modelName`
func (d SwaggerDefinition) parseObjectDefinition(
	modelName, propertyName string,
	input *spec.Schema,
	known internal.ParseResult,
	parsingModel bool,
) (*sdkModels.SDKObjectDefinition, *internal.ParseResult, error) {
	// find the object and any models and constants etc we can find
	// however _don't_ look for discriminator implementations - since that should be done when we're completely done
	result := internal.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	// if it's an enum then parse that out
	if len(input.Enum) > 0 {
		constant, err := constants.MapConstant(input.Type, propertyName, &modelName, input.Enum, input.Extensions)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.Constants[constant.Name] = constant.Details

		definition := sdkModels.SDKObjectDefinition{
			Type:          sdkModels.ReferenceSDKObjectDefinitionType,
			ReferenceName: &constant.Name,
		}

		//TODO: re-enable min/max/unique
		//if input.MaxItems != nil {
		//	v := int(*input.MaxItems)
		//	definition.Maximum = &v
		//}
		//if input.MinItems != nil {
		//	v := int(*input.MinItems)
		//	definition.Minimum = &v
		//}
		//v := input.UniqueItems
		//definition.UniqueItems = &v

		return &definition, &result, nil
	}

	// if it's a reference to a model, return that
	if objectName := fragmentNameFromReference(input.Ref); objectName != nil {
		// first find the top level object
		topLevelObject, err := d.findTopLevelObject(*objectName)
		if err != nil {
			return nil, nil, fmt.Errorf("finding top level model %q: %+v", *objectName, err)
		}

		knownIncludingPlaceholder := internal.ParseResult{
			Constants: map[string]sdkModels.SDKConstant{},
			Models:    map[string]sdkModels.SDKModel{},
		}

		if err := knownIncludingPlaceholder.Append(result); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
		if *objectName != "" {
			knownIncludingPlaceholder.Models[*objectName] = sdkModels.SDKModel{
				// add a placeholder to avoid circular references
			}
		}

		// then call ourselves to work out what to do with it
		objectDefinition, nestedResult, err := d.parseObjectDefinition(*objectName, propertyName, topLevelObject, knownIncludingPlaceholder, true)
		if err != nil {
			return nil, nil, err
		}
		if nestedResult != nil && *objectName != "" {
			delete(nestedResult.Models, *objectName)
		}
		return objectDefinition, nestedResult, nil
	}

	// however we should only do this when we're parsing a model (`parsingModel`) directly rather than when parsing a model from a field - and only if we haven't already parsed this model
	if len(input.Properties) > 0 || len(input.AllOf) > 0 {
		// special-case: if the model has no properties and inherits from one model
		// then just return that object instead, there's no point creating the wrapper type
		if len(input.Properties) == 0 && len(input.AllOf) > 0 {
			// `AllOf` can contain either a Reference, a model/constant or just a description.
			// As such we need to filter out the description-only `AllOf`'s when determining whether the model
			// should be replaced by the single type it's referencing.
			allOfFields := make([]spec.Schema, 0)
			for _, item := range input.AllOf {
				fragmentName := fragmentNameFromReference(item.Ref)
				if fragmentName == nil && len(item.Type) == 0 && len(item.Properties) == 0 {
					continue
				}
				allOfFields = append(allOfFields, item)
			}
			if len(allOfFields) == 1 {
				inheritedModel := allOfFields[0]
				return d.parseObjectDefinition(inheritedModel.Title, propertyName, &inheritedModel, result, true)
			}
		}

		// check for / avoid circular references,
		// however, we should only do this when we're parsing a model (`parsingModel`) directly rather than when parsing a model from a field - and only if we haven't already parsed this model
		if _, ok := result.Models[modelName]; !ok && parsingModel {
			nestedResult, err := d.parseModel(modelName, *input)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing object from inlined model %q: %+v", modelName, err)
			}
			if nestedResult == nil {
				return nil, nil, fmt.Errorf("parsing object from inlined response model %q: no model returned", modelName)
			}
			if err := result.Append(*nestedResult); err != nil {
				return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
			}
		}

		definition := sdkModels.SDKObjectDefinition{
			Type:          sdkModels.ReferenceSDKObjectDefinitionType,
			ReferenceName: &modelName,
		}
		// TODO: re-enable min/max/unique
		//if input.MaxItems != nil {
		//	v := int(*input.MaxItems)
		//	definition.Maximum = &v
		//}
		//if input.MinItems != nil {
		//	v := int(*input.MinItems)
		//	definition.Minimum = &v
		//}
		//v := input.UniqueItems
		//definition.UniqueItems = &v
		return &definition, &result, nil
	}

	if input.AdditionalProperties != nil && input.AdditionalProperties.Schema != nil {
		// it'll be a Dictionary, so pull out the nested item and return that
		// however we need a name for this model
		innerModelName := fmt.Sprintf("%sProperties", propertyName)
		if input.AdditionalProperties.Schema.Title != "" {
			innerModelName = input.AdditionalProperties.Schema.Title
		}

		nestedItem, nestedResult, err := d.parseObjectDefinition(innerModelName, propertyName, input.AdditionalProperties.Schema, result, true)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing nested item for dictionary: %+v", err)
		}
		if nestedItem == nil {
			return nil, nil, fmt.Errorf("parsing nested item for dictionary: no nested item returned")
		}
		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
		return &sdkModels.SDKObjectDefinition{
			Type:       sdkModels.DictionarySDKObjectDefinitionType,
			NestedItem: nestedItem,
		}, &result, nil
	}

	if input.Type.Contains("array") && input.Items.Schema != nil {
		inlinedName := input.Items.Schema.Title
		if inlinedName == "" {
			// generate one based on the info we have
			inlinedName = fmt.Sprintf("%s%sInlined", cleanup.NormalizeName(modelName), cleanup.NormalizeName(propertyName))
		}

		nestedItem, nestedResult, err := d.parseObjectDefinition(inlinedName, propertyName, input.Items.Schema, result, true)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing nested item for array: %+v", err)
		}
		if nestedItem == nil {
			return nil, nil, fmt.Errorf("parsing nested item for array: no nested item returned")
		}

		// TODO: re-enable min/max/unique
		//if input.MaxItems != nil {
		//	v := int(*input.MaxItems)
		//	nestedItem.Maximum = &v
		//}
		//if input.MinItems != nil {
		//	v := int(*input.MinItems)
		//	nestedItem.Minimum = &v
		//}
		//v := input.UniqueItems
		//nestedItem.UniqueItems = &v

		if err := result.Append(*nestedResult); err != nil {
			return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
		}
		return &sdkModels.SDKObjectDefinition{
			Type:       sdkModels.ListSDKObjectDefinitionType,
			NestedItem: nestedItem,
		}, &result, nil
	}

	// Data Factory has a bunch of Custom Types, so we need to check for/handle those
	dataFactoryObjectDefinition, parseResult, err := d.parseDataFactoryCustomTypes(input, known)
	if err != nil {
		return nil, nil, fmt.Errorf("parsing the Data Factory Object Definition: %+v", err)
	}
	if dataFactoryObjectDefinition != nil {
		if parseResult != nil {
			if err := result.Append(*parseResult); err != nil {
				return nil, nil, fmt.Errorf("appending parseResult: %+v", err)
			}
		}
		return dataFactoryObjectDefinition, &result, nil
	}

	// if it's a simple type, there'll be no other objects
	if nativeType := d.parseNativeType(input); nativeType != nil {
		return nativeType, &result, nil
	}

	return nil, nil, fmt.Errorf("unimplemented object definition")
}

func (d SwaggerDefinition) parseDataFactoryCustomTypes(input *spec.Schema, known internal.ParseResult) (*sdkModels.SDKObjectDefinition, *internal.ParseResult, error) {
	formatVal := ""
	if input.Type.Contains("object") {
		formatVal, _ = input.Extensions.GetString("x-ms-format")
	}
	if formatVal == "" {
		return nil, nil, nil
	}

	// DataFactory has a bunch of CustomTypes, which use `"type": "object" and "x-ms-format"` to describe the type
	// as such we need to handle that here
	// Simple Types
	if strings.EqualFold(formatVal, "dfe-bool") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.BooleanSDKObjectDefinitionType,
		}, nil, nil
	}
	if strings.EqualFold(formatVal, "dfe-double") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.FloatSDKObjectDefinitionType,
		}, nil, nil
	}
	if strings.EqualFold(formatVal, "dfe-key-value-pairs") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.DictionarySDKObjectDefinitionType,
			NestedItem: &sdkModels.SDKObjectDefinition{
				Type: sdkModels.StringSDKObjectDefinitionType,
			},
		}, nil, nil
	}
	if strings.EqualFold(formatVal, "dfe-int") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.IntegerSDKObjectDefinitionType,
		}, nil, nil
	}
	if strings.EqualFold(formatVal, "dfe-string") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.StringSDKObjectDefinitionType,
		}, nil, nil
	}

	// DataFactory has some specific reimplementations of List too..
	if strings.EqualFold(formatVal, "dfe-list-generic") && featureflags.ParseDataFactoryListsOfReferencesAsRegularObjectDefinitionTypes {
		// NOTE: it's also possible to have
		elementType, ok := input.Extensions.GetString("x-ms-format-element-type")
		if !ok {
			return nil, nil, fmt.Errorf("when `x-ms-format` is set to `dfe-list-generic` a `x-ms-format-element-type` must be set - but was not found")
		}
		referencedModel, err := d.findTopLevelObject(elementType)
		if err != nil {
			return nil, nil, fmt.Errorf("finding the top-level-object %q: %+v", elementType, err)
		}
		parseResult, err := d.parseModel(elementType, *referencedModel)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing the Model %q: %+v", elementType, err)
		}
		if err := known.Append(*parseResult); err != nil {
			return nil, nil, fmt.Errorf("appending `parseResult`: %+v", err)
		}
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.ListSDKObjectDefinitionType,
			NestedItem: &sdkModels.SDKObjectDefinition{
				Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To(elementType),
			},
		}, &known, nil
	}

	if strings.EqualFold(formatVal, "dfe-list-string") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.ListSDKObjectDefinitionType,
			NestedItem: &sdkModels.SDKObjectDefinition{
				Type: sdkModels.StringSDKObjectDefinitionType,
			},
		}, nil, nil
	}

	// otherwise let this fall through, since the "least bad" thing to do here is to mark this as an object

	return &sdkModels.SDKObjectDefinition{
		Type: sdkModels.RawObjectSDKObjectDefinitionType,
	}, nil, nil
}

func (d SwaggerDefinition) parseNativeType(input *spec.Schema) *sdkModels.SDKObjectDefinition {
	if input == nil {
		return nil
	}

	if input.Type.Contains("bool") || input.Type.Contains("boolean") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.BooleanSDKObjectDefinitionType,
		}
	}

	if input.Type.Contains("file") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.RawFileSDKObjectDefinitionType,
		}
	}

	if input.Type.Contains("integer") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.IntegerSDKObjectDefinitionType,
		}
	}

	if input.Type.Contains("number") {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.FloatSDKObjectDefinitionType,
		}
	}

	if input.Type.Contains("object") {
		if strings.EqualFold(input.Format, "file") {
			return &sdkModels.SDKObjectDefinition{
				Type: sdkModels.RawFileSDKObjectDefinitionType,
			}
		}

		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.RawObjectSDKObjectDefinitionType,
		}
	}

	// NOTE: whilst a DateTime _should_ always be Type: String with a Format of DateTime - bad data means
	// that this could have no Type value but a Format value, so we have to check this separately.
	if strings.EqualFold(input.Format, "date-time") {
		// TODO: handle there being a custom format - for now we assume these are all using RFC3339 (#8)
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.DateTimeSDKObjectDefinitionType,
		}
	}

	if input.Type.Contains("string") {
		// TODO: handle the `format` of `arm-id` (#1289)
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.StringSDKObjectDefinitionType,
		}
	}

	// whilst all fields _should_ have a Type field, it's not guaranteed that they do
	// NOTE: this is _intentionally_ not part of the Object comparison above
	if len(input.Type) == 0 {
		return &sdkModels.SDKObjectDefinition{
			Type: sdkModels.RawObjectSDKObjectDefinitionType,
		}
	}

	return nil
}

func isFieldRequired(name string, required map[string]struct{}) bool {
	for k := range required {
		// assume data inconsistencies
		if strings.EqualFold(k, name) {
			return true
		}
	}

	return false
}
