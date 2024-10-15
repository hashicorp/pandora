// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/featureflags"
)

// ParseObjectDefinition ... TODO
// if `parsingModel` is false, it means the `input` schema cannot be used to parse the model of `modelName`
func (c *Context) ParseObjectDefinition(modelName, propertyName string, input *spec.Schema, known parserModels.ParseResult, parsingModel bool) (*sdkModels.SDKObjectDefinition, *parserModels.ParseResult, error) {
	// find the object and any models and constants etc we can find
	// however _don't_ look for discriminator implementations - since that should be done when we're completely done
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}
	_ = result.Append(known)

	// if it's an enum then parse that out
	if len(input.Enum) > 0 {
		constant, err := constants.Parse(input.Type, propertyName, &modelName, input.Enum, input.Extensions)
		if err != nil {
			return nil, nil, fmt.Errorf("parsing constant: %+v", err)
		}
		result.Constants[constant.Name] = constant.Details

		definition := sdkModels.SDKObjectDefinition{
			Type:          sdkModels.ReferenceSDKObjectDefinitionType,
			ReferenceName: pointer.To(constant.Name),
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
		topLevelObject, err := c.findTopLevelObject(*objectName)
		if err != nil {
			return nil, nil, fmt.Errorf("finding top level model %q: %+v", *objectName, err)
		}

		knownIncludingPlaceholder := parserModels.ParseResult{
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
		const localParsingModel = true
		objectDefinition, nestedResult, err := c.ParseObjectDefinition(*objectName, propertyName, topLevelObject, knownIncludingPlaceholder, localParsingModel)
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
				const localParsingModel = true
				return c.ParseObjectDefinition(inheritedModel.Title, propertyName, &inheritedModel, result, localParsingModel)
			}
		}

		// check for / avoid circular references,
		// however, we should only do this when we're parsing a model (`parsingModel`) directly rather than when parsing a model from a field - and only if we haven't already parsed this model
		if _, ok := result.Models[modelName]; !ok && parsingModel {
			nestedResult, err := c.ParseModel(modelName, *input)
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
			ReferenceName: pointer.To(modelName),
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

		nestedItem, nestedResult, err := c.ParseObjectDefinition(innerModelName, propertyName, input.AdditionalProperties.Schema, result, true)
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

		nestedItem, nestedResult, err := c.ParseObjectDefinition(inlinedName, propertyName, input.Items.Schema, result, true)
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
	dataFactoryObjectDefinition, parseResult, err := c.parseDataFactoryCustomTypes(input, known)
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
	if nativeType := c.parseNativeType(input); nativeType != nil {
		return nativeType, &result, nil
	}

	return nil, nil, fmt.Errorf("unimplemented object definition")
}

func (c *Context) parseDataFactoryCustomTypes(input *spec.Schema, known parserModels.ParseResult) (*sdkModels.SDKObjectDefinition, *parserModels.ParseResult, error) {
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
		referencedModel, err := c.findTopLevelObject(elementType)
		if err != nil {
			return nil, nil, fmt.Errorf("finding the top-level-object %q: %+v", elementType, err)
		}
		parseResult, err := c.ParseModel(elementType, *referencedModel)
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
				ReferenceName: pointer.To(cleanup.Title(elementType)),
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

func (c *Context) parseNativeType(input *spec.Schema) *sdkModels.SDKObjectDefinition {
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
