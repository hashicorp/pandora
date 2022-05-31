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
		if parentModel != nil {
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

%[5]s

namespace %[1]s;

%[4]s
internal %[2]s
{
%[3]s
}
`, namespace, typeInformation, strings.Join(code, "\n\n"), strings.Join(annotations, "\n"), restApiSpecsLicence)
	return &out, nil
}

func (g PandoraDefinitionGenerator) codeForField(indentation, fieldName string, field models.FieldDetails, isTypeHint bool, constants map[string]models.ConstantDetails, knownModels map[string]models.ModelDetails) (*string, error) {
	fieldType, err := dotNetTypeNameForComplexType(field, constants, knownModels)
	if err != nil {
		return nil, err
	}

	lines := make([]string, 0)

	if field.ObjectDefinition != nil {
		innerObjectDefinition := topLevelObjectDefinition(*field.ObjectDefinition)
		if innerObjectDefinition.Minimum != nil {
			lines = append(lines, fmt.Sprintf("%[1]s[MinItems(%[2]d)]", indentation, *innerObjectDefinition.Minimum))
		}
		if innerObjectDefinition.Maximum != nil {
			lines = append(lines, fmt.Sprintf("%[1]s[MaxItems(%[2]d)]", indentation, *innerObjectDefinition.Maximum))
		}

		if field.ObjectDefinition.Type == models.ObjectDefinitionDateTime {
			// TODO: support for custom date formats
			lines = append(lines, fmt.Sprintf("%[1]s[DateFormat(DateFormatAttribute.DateFormat.RFC3339)]", indentation))
		}
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
	case models.ObjectDefinitionCsv:
		{
			if input.ReferenceName != nil {
				if _, isConstant := constants[*input.ReferenceName]; isConstant {
					return nilableValue(fmt.Sprintf("Csv<%sConstant>", *input.ReferenceName))
				}
				if _, isModel := knownModels[*input.ReferenceName]; isModel {
					return nilableValue(fmt.Sprintf("Csv<%sModel>", *input.ReferenceName))
				}

				return nil, fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
			}

			if input.NestedItem == nil {
				return nil, fmt.Errorf("a Csv must have a reference or a nested item but got neither")
			}

			innerType, err := dotNetNameForObjectDefinition(input.NestedItem, constants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("determining inner type for object definition: %+v", err)
			}
			return nilableValue(fmt.Sprintf("Csv<%s>", *innerType))
		}

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

			// is this a constant or a model
			if _, isConstant := constants[*input.ReferenceName]; isConstant {
				val := fmt.Sprintf("%sConstant", *input.ReferenceName)
				return &val, nil
			}
			if _, isModel := knownModels[*input.ReferenceName]; isModel {
				val := fmt.Sprintf("%sModel", *input.ReferenceName)
				return &val, nil
			}

			return nil, fmt.Errorf("the Reference %q wasn't found as a Constant or a Model", *input.ReferenceName)
		}

	case models.ObjectDefinitionBoolean:
		return nilableValue("bool")

	case models.ObjectDefinitionDateTime:
		return nilableValue("DateTime")

	case models.ObjectDefinitionFloat:
		return nilableValue("float")

	case models.ObjectDefinitionInteger:
		return nilableValue("int")

	// this is using RawFile and not `byte[]` since byte streams are also possible but aren't files
	case models.ObjectDefinitionRawFile:
		return nilableValue("CustomTypes.RawFile")

	case models.ObjectDefinitionRawObject:
		return nilableValue("object")

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
	case models.CustomFieldTypeEdgeZone:
		return nilableType("CustomTypes.EdgeZone")

	case models.CustomFieldTypeLocation:
		return nilableType("CustomTypes.Location")

	case models.CustomFieldTypeTags:
		return nilableType("CustomTypes.Tags")

	case models.CustomFieldTypeSystemAssignedIdentity:
		return nilableType("CustomTypes.SystemAssignedIdentity")

	case models.CustomFieldTypeSystemAndUserAssignedIdentityList:
		return nilableType("CustomTypes.SystemAndUserAssignedIdentityList")

	case models.CustomFieldTypeSystemAndUserAssignedIdentityMap:
		return nilableType("CustomTypes.SystemAndUserAssignedIdentityMap")

	case models.CustomFieldTypeLegacySystemAndUserAssignedIdentityList:
		return nilableType("CustomTypes.LegacySystemAndUserAssignedIdentityList")

	case models.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:
		return nilableType("CustomTypes.LegacySystemAndUserAssignedIdentityMap")

	case models.CustomFieldTypeSystemOrUserAssignedIdentityList:
		return nilableType("CustomTypes.SystemOrUserAssignedIdentityList")

	case models.CustomFieldTypeSystemOrUserAssignedIdentityMap:
		return nilableType("CustomTypes.SystemOrUserAssignedIdentityMap")

	case models.CustomFieldTypeUserAssignedIdentityList:
		return nilableType("CustomTypes.UserAssignedIdentityList")

	case models.CustomFieldTypeUserAssignedIdentityMap:
		return nilableType("CustomTypes.UserAssignedIdentityMap")
	case models.CustomFieldTypeSystemData:
		return nilableType("CustomTypes.SystemData")
	}

	return nil, fmt.Errorf("unmapped Custom Type %q", string(input))
}

// topLevelObjectDefinition returns the top level object definition, that is a Constant or Model (or simple type) directly
func topLevelObjectDefinition(input models.ObjectDefinition) models.ObjectDefinition {
	if input.NestedItem != nil {
		return topLevelObjectDefinition(*input.NestedItem)
	}

	return input
}
