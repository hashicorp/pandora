// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"encoding/json"
	"fmt"
	"reflect"
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mappingDefinitionsMatch(t *testing.T, actual *sdkModels.TerraformMappingDefinition, expected sdkModels.TerraformMappingDefinition) {
	if actual == nil {
		t.Fatalf("actual was nil")
	}

	if !mappingsMatch(t, actual.Fields, expected.Fields) {
		t.Fatalf("expected and actual for Fields Mappings differ - expected %+v - actual %+v", expected.Fields, actual.Fields)
	}
}

func mappingsMatch(t *testing.T, expected []sdkModels.TerraformFieldMappingDefinition, actual []sdkModels.TerraformFieldMappingDefinition) bool {
	if len(actual) != len(expected) {
		return false
	}

	for _, expectedItem := range expected {
		presentInActual := false
		for _, actualItem := range actual {
			if mappingTypesMatch(t, expectedItem, actualItem) {
				presentInActual = true
				break
			}
		}
		if !presentInActual {
			t.Fatalf("expected mapping %+v was not found in actual", expectedItem)
		}
	}

	return true
}

func mappingTypesMatch(t *testing.T, first sdkModels.TerraformFieldMappingDefinition, second sdkModels.TerraformFieldMappingDefinition) bool {
	firstEncoded, err := marshalValue(first)
	if err != nil {
		t.Fatalf("encoding first: %+v", err)
		return false
	}
	secondEncoded, err := marshalValue(second)
	if err != nil {
		t.Fatalf("encoding second: %+v", err)
		return false
	}
	if !reflect.DeepEqual(firstEncoded, secondEncoded) {
		t.Fatalf("mapping types didn't match - first [%+v] - second [%+v]", firstEncoded, secondEncoded)
		return false
	}
	return true
}

func modelDefinitionsMatch(t *testing.T, actual map[string]sdkModels.TerraformSchemaModel, expected map[string]sdkModels.TerraformSchemaModel) {
	if actual == nil {
		t.Fatalf("actual was nil")
	}
	if len(actual) != len(expected) {
		t.Fatalf("actual had %d models but expected had %d models", len(actual), len(expected))
	}

	for key, firstVal := range actual {
		secondVal, ok := expected[key]
		if !ok {
			t.Fatalf("key %q was present in actual but not expected", key)
		}

		if !fieldDefinitionsMatch(t, key, firstVal.Fields, secondVal.Fields) {
			t.Fatalf("field definitions didn't match for model %q", key)
		}
	}
}

func fieldDefinitionsMatch(t *testing.T, modelName string, first map[string]sdkModels.TerraformSchemaField, second map[string]sdkModels.TerraformSchemaField) bool {
	// we can't use reflect.DeepEqual since there's pointers involved, so we'll do this the old-fashioned way
	if len(first) != len(second) {
		t.Fatalf("model %q - first had %d fields but second had %d fields.\nFirst: %+v\nSecond: %+v", modelName, len(first), len(second), first, second)
		return false
	}

	for fieldKey, firstVal := range first {
		secondVal, ok := second[fieldKey]
		if !ok {
			t.Fatalf("field %q was present in first but not second", fieldKey)
			return false
		}

		if firstVal.Computed != secondVal.Computed {
			t.Fatalf("first computed %t != second computed %t", firstVal.Computed, secondVal.Computed)
		}
		if firstVal.ForceNew != secondVal.ForceNew {
			t.Fatalf("first forcenew %t != second forcenew %t", firstVal.ForceNew, secondVal.ForceNew)
		}
		if firstVal.HCLName != secondVal.HCLName {
			t.Fatalf("first hclName %q != second hclName %q", firstVal.HCLName, secondVal.HCLName)
		}
		if firstVal.Optional != secondVal.Optional {
			t.Fatalf("first optional %t != second optional %t", firstVal.Optional, secondVal.Optional)
		}
		if firstVal.Required != secondVal.Required {
			t.Fatalf("first required %t != second required %t", firstVal.Required, secondVal.Required)
		}
		if !reflect.DeepEqual(firstVal.Documentation, secondVal.Documentation) {
			t.Fatalf("first documentation %+v != second documentation %+v", firstVal.Documentation, secondVal.Documentation)
		}

		if !objectDefinitionsMatch(t, &firstVal.ObjectDefinition, &secondVal.ObjectDefinition) {
			t.Fatalf("object definitions didn't match")
			return false
		}

		// TODO - Put this, or equivalent, back when mappings are re-implemented
		//if !mappingsMatch(t, firstVal.Mappings, secondVal.Mappings) {
		//	t.Fatalf("mappings didn't match")
		//	return false
		//}

		if !validatorsMatch(t, firstVal.Validation, secondVal.Validation) {
			t.Fatalf("validation didn't match")
			return false
		}
	}

	return true
}

func objectDefinitionsMatch(t *testing.T, first *sdkModels.TerraformSchemaObjectDefinition, second *sdkModels.TerraformSchemaObjectDefinition) bool {
	if first == nil && second == nil {
		return true
	}
	if first != nil && second == nil {
		t.Fatalf("first was %+v but second was nil", *first)
		return false
	}
	if first == nil && second != nil {
		t.Fatalf("first was nil but second wasn't: %+v", *second)
		return false
	}

	if first.Type != second.Type {
		t.Fatalf("type's didn't match - first %q / second %q", string(first.Type), string(second.Type))
		return false
	}
	firstRefName := valueForNilableString(first.ReferenceName)
	secondRefName := valueForNilableString(second.ReferenceName)
	if firstRefName != secondRefName {
		t.Fatalf("reference name's didn't match - first %q / second %q", firstRefName, secondRefName)
		return false
	}
	if !objectDefinitionsMatch(t, first.NestedObject, second.NestedObject) {
		t.Fatalf("Nested ObjectDefinition's didn't match - first %+v / second %+v", *first.NestedObject, *second.NestedObject)
		return false
	}

	return true
}

func validatorsMatch(t *testing.T, first sdkModels.TerraformSchemaFieldValidationDefinition, second sdkModels.TerraformSchemaFieldValidationDefinition) bool {
	if first == nil && second == nil {
		return true
	}
	if first != nil && second == nil {
		t.Fatalf("first was %+v but second was nil", first)
		return false
	}
	if first == nil && second != nil {
		t.Fatalf("first was nil but second wasn't: %+v", second)
		return false
	}

	// since these can be different types which contain pointers, comparing the JSON-encoded values is probably the least hassle
	firstEncoded, err := marshalValue(first)
	if err != nil {
		t.Fatalf("encoding first: %+v", err)
		return false
	}
	secondEncoded, err := marshalValue(second)
	if err != nil {
		t.Fatalf("encoding second: %+v", err)
		return false
	}

	if !reflect.DeepEqual(firstEncoded, secondEncoded) {
		t.Fatalf("validation values didn't match - first [%+v] / second [%+v]", firstEncoded, secondEncoded)
		return false
	}

	return true
}

func marshalValue(input any) (map[string]any, error) {
	encoded, err := json.Marshal(input)
	if err != nil {
		return nil, err
	}

	var out map[string]any
	if err := json.Unmarshal(encoded, &out); err != nil {
		return nil, fmt.Errorf("decoding into `map[string]any`: %+v", err)
	}
	return out, nil
}

func stringifyValues(input []interface{}) []string {
	output := make([]string, 0)

	if input != nil {
		for _, val := range input {
			v, ok := val.(string)
			if ok {
				output = append(output, v)
			}
		}
	}

	return output
}

func valueForNilableString(input *string) string {
	if input == nil {
		return ""
	}

	return *input
}

func stringPointer(input string) *string {
	return &input
}
