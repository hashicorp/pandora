package schema

import (
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

func GetField(model resourcemanager.ModelDetails, fieldName string) (*resourcemanager.FieldDetails, bool) {
	for field, val := range model.Fields {
		if strings.EqualFold(field, fieldName) {
			return &val, true
		}
	}

	return nil, false
}

func updateFieldName(fieldName string, model *resourcemanager.ModelDetails, resource *resourcemanager.TerraformResourceDetails) string {
	metadata := processors.FieldMetadata{
		TerraformDetails: *resource,
		Model:            *model,
	}
	for _, matcher := range processors.NamingRules {
		if updatedFieldName, _ := matcher.ProcessField(fieldName, metadata); updatedFieldName != nil {
			return *updatedFieldName
		}
	}
	return fieldName
}

func stringPointer(input string) *string {
	return &input
}
