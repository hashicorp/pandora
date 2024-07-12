package parsingcontext

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"strings"

	"github.com/go-openapi/spec"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

func (c *Context) ParseModel(name string, input spec.Schema, loadParentType bool) (*parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	// 1. find any constants used within this model
	nestedResult, err := c.findConstantsWithinModel(name, nil, input, result)
	if err != nil {
		return nil, fmt.Errorf("finding constants within model: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from constants: %+v", err)
	}

	// 2. iterate over the fields and find all of the fields for this model
	fields, nestedResult, err := c.fieldsForModel(name, input, result, loadParentType)
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
	model, err := c.modelDetailsFromObject(name, input, *fields, loadParentType)
	if err != nil {
		return nil, fmt.Errorf("populating model details for %q: %+v", name, err)
	}
	result.Models[name] = *model

	return &result, nil
}

func (c *Context) findConstantsWithinModel(fieldName string, modelName *string, input spec.Schema, known parserModels.ParseResult) (*parserModels.ParseResult, error) {
	// NOTE: both Models and Fields are passed in here
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	if len(input.Enum) > 0 {
		constant, err := constants.Parse(input.Type, fieldName, modelName, input.Enum, input.Extensions)
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

			topLevelModel, err := c.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("finding top level model %q for constants: %+v", *fragmentName, err)
			}

			nestedResult, err := c.findConstantsWithinModel(*fragmentName, &fieldName, *topLevelModel, result)
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
		nestedResult, err := c.findConstantsWithinModel(propName, &fieldName, propVal, result)
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
			nestedConstants, err := c.findConstantsWithinModel(propName, &fieldName, propVal, result)
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

func (c *Context) detailsForField(modelName string, propertyName string, value spec.Schema, isRequired bool, known parserModels.ParseResult, loadParentType bool) (*sdkModels.SDKField, *parserModels.ParseResult, error) {
	logging.Tracef("Parsing details for field %q in %q..", propertyName, modelName)

	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	result.Append(known)

	field := sdkModels.SDKField{
		Required:    isRequired,
		Optional:    !isRequired, //TODO: re-enable readonly && !value.ReadOnly,
		ReadOnly:    false,       // TODO: re-enable readonly value.ReadOnly,
		Sensitive:   false,       // todo: this probably needs to be a predefined list, unless there's something we can parse
		JsonName:    propertyName,
		Description: value.Description,
	}

	// first get the object definition
	parsingModel := false
	objectDefinition, nestedResult, err := c.ParseObjectDefinition(modelName, propertyName, &value, result, parsingModel, loadParentType)
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
			nestedField, nestedResult, err := c.detailsForField(inlinedName, propName, propVal, nestedFieldRequired, result, loadParentType)
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

			remoteSpec, err := c.findTopLevelObject(*remoteRef)
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
				nestedField, nestedResult, err := c.detailsForField(inlinedName, propName, propVal, nestedFieldRequired, result, loadParentType)
				if err != nil {
					return nil, nil, fmt.Errorf("parsing inlined model %q: %+v", inlinedName, err)
				}
				if err := result.Append(*nestedResult); err != nil {
					return nil, nil, fmt.Errorf("appending nestedResult: %+v", err)
				}
				nestedFields[propName] = *nestedField
			}
		}

		inlinedModelDetails, err := c.modelDetailsFromObject(inlinedName, value, nestedFields, loadParentType)
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

func (c *Context) fieldsForModel(modelName string, input spec.Schema, known parserModels.ParseResult, loadParentType bool) (*map[string]sdkModels.SDKField, *parserModels.ParseResult, error) {
	fields := make(map[string]sdkModels.SDKField, 0)
	result := parserModels.ParseResult{
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
			// >            "description": "EventGrid secondary accesskey. Will be obfuscated during reac.",
			// >            "type": "string",
			// >          "x-nullable": true
			// >         },
			// >         "accessKey2": {
			// >           "x-ms-secret": true,
			// >           "description": "EventGrid secondary accesskey. Will be obfuscated during reac.",
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
				parsedParent, nestedResult, err := c.fieldsForModel(innerModelName, parent, known, true)
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

		topLevelObject, err := c.findTopLevelObject(*fragmentName)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing top level object %q: %+v", *fragmentName, err)
		}
		for _, k := range topLevelObject.Required {
			requiredFields[k] = struct{}{}
		}

		nestedFields, nestedResult, err := c.fieldsForModel(*fragmentName, *topLevelObject, result, loadParentType)
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
		field, nestedResult, err := c.detailsForField(modelName, propName, propVal, isRequired, result, loadParentType)
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

func (c *Context) modelDetailsFromObject(modelName string, input spec.Schema, fields map[string]sdkModels.SDKField, loadParentType bool) (*sdkModels.SDKModel, error) {
	details := sdkModels.SDKModel{
		Fields: fields,
	}

	// if this is a Parent
	if input.Discriminator != "" {
		details.FieldNameContainingDiscriminatedValue = &input.Discriminator

		// check that there's at least one implementation of this type - otherwise this this isn't a discriminated type
		// but bad data we should ignore
		implementations, err := c.findModelNamesWhichImplement(modelName)
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

		// NOTE: we want the option to conditionally load the parent type to be able to load the Supplementary Data
		// first (since these may only contain the Discriminated Implementations and not the Parent Type).
		if loadParentType {
			// so we need to find the ancestor details
			parentTypeName, discriminator, err := c.FindAncestorType(input)
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

	}

	return &details, nil
}

func (c *Context) FindAncestorType(input spec.Schema) (*string, *string, error) {
	for _, parentRaw := range input.AllOf {
		parentFragmentName := fragmentNameFromReference(parentRaw.Ref)
		if parentFragmentName == nil {
			continue
		}

		parent, err := c.findTopLevelObject(*parentFragmentName)
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

		parentTypeName, discriminator, err := c.FindAncestorType(*parent)
		if err != nil {
			return nil, nil, fmt.Errorf("finding ancestor type for %q: %+v", *parentFragmentName, err)
		}
		if parentTypeName != nil && discriminator != nil {
			return parentTypeName, discriminator, nil
		}
	}
	return nil, nil, nil
}

func (c *Context) findOrphanedDiscriminatedModels(serviceName string) (*parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	for modelName, definition := range c.SwaggerSpecRaw.Definitions {
		if _, ok := definition.Extensions.GetString("x-ms-discriminator-value"); ok {
			details, err := c.ParseModel(modelName, definition, false)
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
				parentType, discriminator, err := c.FindAncestorType(definition)
				if err != nil {
					return nil, fmt.Errorf("determining ancestor type for model %q: %+v", modelName, err)
				}

				details, err := c.ParseModel(modelName, definition, false)
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
	nestedResult, err := c.FindNestedItemsYetToBeParsed(map[string]sdkModels.SDKOperation{}, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	}

	return &result, nil
}
