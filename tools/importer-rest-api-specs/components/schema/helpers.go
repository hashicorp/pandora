package schema

import (
	"fmt"
	"sort"
	"strings"
	"unicode"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema/processors"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func convertToSnakeCase(input string) string {
	if v, ok := schemaFieldNameOverrides[strings.ToLower(input)]; ok {
		return v
	}

	splitIdxMap := map[int]struct{}{}
	var lastChar rune
	for idx, char := range input {
		switch {
		case idx == 0:
			splitIdxMap[idx] = struct{}{}
		case unicode.IsUpper(lastChar) == unicode.IsUpper(char):
		case unicode.IsUpper(lastChar):
			splitIdxMap[idx-1] = struct{}{}
		case unicode.IsUpper(char):
			splitIdxMap[idx] = struct{}{}
		}
		lastChar = char
	}
	splitIdx := make([]int, 0, len(splitIdxMap))
	for idx := range splitIdxMap {
		splitIdx = append(splitIdx, idx)
	}
	sort.Ints(splitIdx)

	inputRunes := []rune(input)
	out := make([]string, len(splitIdx))
	for i := range splitIdx {
		if i == len(splitIdx)-1 {
			out[i] = strings.ToLower(string(inputRunes[splitIdx[i]:]))
			continue
		}
		out[i] = strings.ToLower(string(inputRunes[splitIdx[i]:splitIdx[i+1]]))
	}
	return strings.Join(out, "_")
}

func fieldShouldBeIgnored(key string, definition resourcemanager.FieldDetails, constants map[string]resourcemanager.ConstantDetails) bool {
	for _, v := range fieldsWhichShouldBeIgnoredExactMatch {
		if strings.EqualFold(key, v) {
			return true
		}
	}

	lowered := strings.ToLower(key)
	for _, v := range fieldsWhichShouldBeIgnoredIfContains {
		if strings.Contains(lowered, strings.ToLower(v)) {
			return true
		}
	}

	// due to differences in the source data, we need to handle both the field being a constant and a string value
	if strings.Contains(lowered, "state") || strings.Contains(lowered, "status") {
		if definition.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			// if it's a reference to a constant, it can be skipped
			if _, ok := constants[*definition.ObjectDefinition.ReferenceName]; ok {
				return true
			}
		}

		// some "State" fields aren't defined as
		if definition.ObjectDefinition.Type == resourcemanager.StringApiObjectDefinitionType {
			return true
		}
	}

	return false
}

func getField(model resourcemanager.ModelDetails, fieldName string) (*resourcemanager.FieldDetails, bool) {
	for field, val := range model.Fields {
		if strings.EqualFold(field, fieldName) {
			return &val, true
		}
	}

	return nil, false
}

func updateFieldName(fieldName string, model *resourcemanager.ModelDetails, resource *resourcemanager.TerraformResourceDetails) (string, error) {
	metadata := processors.FieldMetadata{
		TerraformDetails: *resource,
		Model:            *model,
	}
	for _, matcher := range processors.NamingRules {
		updatedFieldName, err := matcher.ProcessField(fieldName, metadata)
		if err != nil {
			return "", err
		}

		if updatedFieldName != nil {
			return *updatedFieldName, nil
		}
	}
	return fieldName, nil
}

func stringPointer(input string) *string {
	return &input
}

func getFieldValidation(input *resourcemanager.FieldValidationDetails, fieldName string) (*resourcemanager.TerraformSchemaValidationDefinition, error) {
	if input == nil {
		return nil, nil
	}
	var validationType resourcemanager.TerraformSchemaValidationType
	var possibleValues *resourcemanager.TerraformSchemaValidationPossibleValuesDefinition
	switch input.Type {
	case resourcemanager.RangeValidation:
		validationType = resourcemanager.TerraformSchemaValidationTypePossibleValues
		if values := input.Values; values == nil || len(*values) == 0 {
			return nil, fmt.Errorf("field %q had Range Validation type but had no defined values", fieldName)
		} else {
			t := (*values)[0]
			switch t.(type) {
			case string:
				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeString,
					Values: *values,
				}
				break

			case int, int32, int64:
				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeInt,
					Values: *values,
				}
				break

			case float32, float64:
				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat,
					Values: *values,
				}
				break
			}
		}
	}

	return &resourcemanager.TerraformSchemaValidationDefinition{
		Type:           validationType,
		PossibleValues: possibleValues,
	}, nil
}
