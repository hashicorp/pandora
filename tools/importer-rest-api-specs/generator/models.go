package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForModel(namespace string, modelName string, model models.ModelDetails, parentModel *models.ModelDetails, knownConstants map[string]models.ConstantDetails, knownModels map[string]models.ModelDetails) (*string, error) {
	if len(model.Fields) == 0 {
		return nil, fmt.Errorf("the model %q in namespace %q has no fields", modelName, namespace)
	}

	code := make([]string, 0)

	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	for _, fieldName := range sortedFieldNames {
		// we should skip outputting this field if it's present on the parent
		fieldInParent := false
		if parentModel != nil && parentModel.TypeHintValue != nil {
			// the importer flattens fields from parents/AllOf, since we don't use inheritance for that within the
			// data layer - as such we only want to skip the fields when the parent type is output, e.g. when there's
			// a discriminator involved
			for name := range parentModel.Fields {
				if strings.EqualFold(name, fieldName) {
					fieldInParent = true
					break
				}
			}
		}
		if fieldInParent {
			continue
		}

		field := model.Fields[fieldName]
		isTypeHint := model.TypeHintIn != nil && strings.EqualFold(*model.TypeHintIn, fieldName)
		fieldCode, err := g.codeForField("\t\t", fieldName, field, isTypeHint, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}
		code = append(code, *fieldCode)
	}

	typeInformation := fmt.Sprintf("class %sModel", modelName)
	if model.TypeHintIn != nil {
		if model.ParentTypeName != nil {
			typeInformation = fmt.Sprintf("%s : %sModel", typeInformation, *model.ParentTypeName)
		} else {
			// this is a discriminator/parent
			typeInformation = fmt.Sprintf("abstract %s", typeInformation)
		}
	}

	annotations := make([]string, 0)
	if model.TypeHintValue != nil {
		annotations = append(annotations, fmt.Sprintf("\t[ValueForType(%q)]", *model.TypeHintValue))
	}

	out := fmt.Sprintf(`using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace %[1]s
{
%[4]s
	internal %[2]s
	{
%[3]s
	}
}
`, namespace, typeInformation, strings.Join(code, "\n\n"), strings.Join(annotations, "\n"))
	return &out, nil
}

func (g PandoraDefinitionGenerator) codeForField(indentation, fieldName string, field models.FieldDetails, isTypeHint bool, constants map[string]models.ConstantDetails, knownModels map[string]models.ModelDetails) (*string, error) {
	fieldType, err := dotNetTypeNameForComplexType(field, constants, knownModels)
	if err != nil {
		return nil, err
	}

	lines := make([]string, 0)

	if field.ObjectDefinition != nil && field.ObjectDefinition.Type == models.ObjectDefinitionDateTime {
		// TODO: support for custom date formats
		lines = append(lines, fmt.Sprintf("%[1]s[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]", indentation))
	}

	lines = append(lines, fmt.Sprintf("%[1]s[JsonPropertyName(%[2]q)]", indentation, field.JsonName))

	if isTypeHint {
		lines = append(lines, fmt.Sprintf("%[1]s[ProvidesTypeHint]", indentation))
	}

	if field.Required {
		lines = append(lines, fmt.Sprintf("%[1]s[Required]", indentation))
	} else {
		typeName := fmt.Sprintf("%s?", *fieldType)
		fieldType = &typeName
	}

	if field.Minimum != nil {
		lines = append(lines, fmt.Sprintf("%[1]s[MinItems(%[2]d)]", indentation, *field.Minimum))
	}
	if field.Maximum != nil {
		lines = append(lines, fmt.Sprintf("%[1]s[MaxItems(%[2]d)]", indentation, *field.Maximum))
	}

	lines = append(lines, fmt.Sprintf("%[1]spublic %[2]s %[3]s { get; set; }", indentation, *fieldType, strings.Title(fieldName)))
	out := strings.Join(lines, "\n")
	return &out, nil
}

func dotNetTypeNameForComplexType(field models.FieldDetails, constants map[string]models.ConstantDetails, models map[string]models.ModelDetails) (*string, error) {
	if field.CustomFieldType != nil {
		return dotNetTypeNameForCustomType(*field.CustomFieldType)
	}

	return dotNetNameForObjectDefinition(field.ObjectDefinition, constants, models)
}

func dotNetNameForObjectDefinition(input *models.ObjectDefinition, constants map[string]models.ConstantDetails, knownModels map[string]models.ModelDetails) (*string, error) {
	if input == nil {
		return nil, fmt.Errorf("missing object definition")
	}

	var nilableValue = func(in string) (*string, error) {
		return &in, nil
	}

	switch input.Type {
	case models.ObjectDefinitionDictionary:
		{
			if input.ReferenceName != nil {
				if _, isConstant := constants[*input.ReferenceName]; isConstant {
					return nilableValue(fmt.Sprintf("Dictionary<string, %sConstant>", *input.ReferenceName))
				}
				if _, isModel := knownModels[*input.ReferenceName]; isModel {
					return nilableValue(fmt.Sprintf("Dictionary<string, %sModel>", *input.ReferenceName))
				}

				return nil, fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
			}

			if input.NestedItem == nil {
				return nil, fmt.Errorf("a dictionary must have a reference or a nested item but got neither")
			}

			innerType, err := dotNetNameForObjectDefinition(input.NestedItem, constants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("determining inner type for object definition: %+v", err)
			}
			return nilableValue(fmt.Sprintf("Dictionary<string, %s>", *innerType))
		}

	case models.ObjectDefinitionList:
		{
			if input.ReferenceName != nil {
				if _, isConstant := constants[*input.ReferenceName]; isConstant {
					return nilableValue(fmt.Sprintf("List<%sConstant>", *input.ReferenceName))
				}
				if _, isModel := knownModels[*input.ReferenceName]; isModel {
					return nilableValue(fmt.Sprintf("List<%sModel>", *input.ReferenceName))
				}

				return nil, fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
			}

			if input.NestedItem == nil {
				return nil, fmt.Errorf("a list item must have a reference or a nested item but got neither")
			}

			innerType, err := dotNetNameForObjectDefinition(input.NestedItem, constants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("determining inner type for object definition: %+v", err)
			}
			return nilableValue(fmt.Sprintf("List<%s>", *innerType))
		}

	case models.ObjectDefinitionReference:
		{
			if input.ReferenceName == nil {
				return nil, fmt.Errorf("a reference must have a reference name but didn't get one")
			}

			return input.ReferenceName, nil
		}

	case models.ObjectDefinitionBoolean:
		return nilableValue("bool")

	case models.ObjectDefinitionDateTime:
		return nilableValue("DateTime")

	case models.ObjectDefinitionFloat:
		return nilableValue("float")

	case models.ObjectDefinitionInteger:
		return nilableValue("int")

	case models.ObjectDefinitionString:
		return nilableValue("string")
	}

	return nil, fmt.Errorf("unmapped object definition value: %+v", *input)
}

func dotNetTypeNameForCustomType(input models.CustomFieldType) (*string, error) {
	var nilableType = func(in string) (*string, error) {
		return &in, nil
	}

	switch input {
	case models.CustomFieldTypeLocation:
		return nilableType("CustomTypes.Location")

	case models.CustomFieldTypeTags:
		return nilableType("CustomTypes.Tags")

	case models.CustomFieldTypeSystemAssignedIdentity:
		return nilableType("CustomTypes.SystemAssignedIdentity")

	case models.CustomFieldTypeSystemAssignedUserAssignedIdentityList:
		return nilableType("CustomTypes.SystemUserAssignedIdentityList")

	case models.CustomFieldTypeSystemAssignedUserAssignedIdentityMap:
		return nilableType("CustomTypes.SystemUserAssignedIdentityMap")

	case models.CustomFieldTypeUserAssignedIdentityList:
		return nilableType("CustomTypes.UserAssignedIdentityList")

	case models.CustomFieldTypeUserAssignedIdentityMap:
		return nilableType("CustomTypes.UserAssignedIdentityMap")
	}

	return nil, fmt.Errorf("unmapped Custom Type %q", string(input))
}
