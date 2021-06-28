package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForModel(namespace string, modelName string, model models.ModelDetails, parentModel *models.ModelDetails) (*string, error) {
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
		fieldCode, err := g.codeForField("\t\t", fieldName, field, isTypeHint)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}
		code = append(code, *fieldCode)
	}

	typeInformation := fmt.Sprintf("class %s", modelName)
	if model.TypeHintIn != nil {
		if model.ParentTypeName != nil {
			typeInformation = fmt.Sprintf("%s : %s", typeInformation, *model.ParentTypeName)
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

func (g PandoraDefinitionGenerator) codeForField(indentation, fieldName string, field models.FieldDefinition, isTypeHint bool) (*string, error) {
	fieldType, err := dotNetTypeNameForComplexType(field)
	if err != nil {
		return nil, err
	}

	lines := make([]string, 0)

	if field.Type == models.DateTime {
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

	if field.ListElementMin != nil {
		lines = append(lines, fmt.Sprintf("%[1]s[MinItems(%[2]d)]", indentation, *field.ListElementMin))
	}
	if field.ListElementMax != nil {
		lines = append(lines, fmt.Sprintf("%[1]s[MaxItems(%[2]d)]", indentation, *field.ListElementMax))
	}

	lines = append(lines, fmt.Sprintf("%[1]spublic %[2]s %[3]s { get; set; }", indentation, *fieldType, strings.Title(fieldName)))
	out := strings.Join(lines, "\n")
	return &out, nil
}

func dotNetTypeNameForComplexType(field models.FieldDefinition) (*string, error) {
	var nilableType = func(input string) (*string, error) {
		return &input, nil
	}

	switch field.Type {
	case models.Boolean, models.DateTime, models.Float, models.Integer, models.String:
		return dotNetTypeNameForSimpleType(field.Type)

	case models.Dictionary:
		{
			if field.ConstantReference != nil {
				return nilableType(fmt.Sprintf("Dictionary<string, %s>", *field.ConstantReference))
			}
			if field.ModelReference != nil {
				return nilableType(fmt.Sprintf("Dictionary<string, %s>", *field.ModelReference))
			}

			// TODO: we could have keys of other types, but this is likely fine for now
			return nil, fmt.Errorf("the Dictionary has no Nested Element Type")
		}

	case models.List:
		{
			if field.ConstantReference != nil {
				return nilableType(fmt.Sprintf("List<%s>", *field.ConstantReference))
			}
			if field.ModelReference != nil {
				return nilableType(fmt.Sprintf("List<%s>", *field.ModelReference))
			}
			if field.ListElementType != nil {
				nestedType := ""
				if *field.ListElementType == models.Object {
					// not ideal, but it'll do for now since there's no definition for this
					nestedType = "object"
				} else {
					nestedTypeName, err := dotNetTypeNameForSimpleType(*field.ListElementType)
					if err != nil {
						return nil, fmt.Errorf("determining Type for nested Element %q: %+v", string(*field.ListElementType), err)
					}
					nestedType = *nestedTypeName
				}

				return nilableType(fmt.Sprintf("List<%s>", nestedType))
			}

			return nil, fmt.Errorf("the List has no Nested Element Type")
		}

	case models.Object:
		if field.ConstantReference != nil {
			return nilableType(*field.ConstantReference)
		}
		if field.ModelReference != nil {
			return nilableType(*field.ModelReference)
		}

		// for example JSON fields
		return nilableType("object")

	// Custom Types exist for these
	case models.Location:
		return nilableType("CustomTypes.Location")
	case models.Tags:
		return nilableType("CustomTypes.Tags")
	}

	return nil, fmt.Errorf(fmt.Sprintf("TODO: unsupported type %q", string(field.Type)))
}

func dotNetTypeNameForSimpleType(input models.FieldDefinitionType) (*string, error) {
	var nilableType = func(input string) (*string, error) {
		return &input, nil
	}

	switch input {
	case models.Boolean:
		return nilableType("bool")

	case models.DateTime:
		return nilableType("DateTime")

	case models.Float:
		return nilableType("float")

	case models.Integer:
		return nilableType("int")

	case models.String:
		return nilableType("string")
	}

	return nil, fmt.Errorf("type %q is not a simple type", string(input))
}
