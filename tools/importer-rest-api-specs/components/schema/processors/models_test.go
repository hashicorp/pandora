package processors

import (
	"fmt"
	"reflect"
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mappingDefinitionsMatch(t *testing.T, actual *resourcemanager.MappingDefinition, expected resourcemanager.MappingDefinition) {
	if actual == nil {
		t.Fatalf("actual was nil")
	}

	if !mappingsMatch(t, actual.Fields, expected.Fields) {
		t.Fatalf("expected and actual for Fields Mappings differ - expected %+v - actual %+v", expected.Fields, actual.Fields)
	}
}

func mappingsMatch(t *testing.T, expected []resourcemanager.FieldMappingDefinition, actual []resourcemanager.FieldMappingDefinition) bool {
	if len(actual) != len(expected) {
		return false
	}

	for _, expectedItem := range expected {
		presentInActual := false
		for _, actualItem := range actual {
			if mappingTypesMatch(expectedItem, actualItem) {
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

func mappingTypesMatch(first resourcemanager.FieldMappingDefinition, second resourcemanager.FieldMappingDefinition) bool {
	if first.Type != second.Type {
		return false
	}

	switch first.Type {
	case resourcemanager.DirectAssignmentMappingDefinitionType:
		{
			if first.DirectAssignment.SchemaModelName != second.DirectAssignment.SchemaModelName {
				return false
			}
			if first.DirectAssignment.SchemaFieldPath != second.DirectAssignment.SchemaFieldPath {
				return false
			}
			if first.DirectAssignment.SdkModelName != second.DirectAssignment.SdkModelName {
				return false
			}
			if first.DirectAssignment.SdkFieldPath != second.DirectAssignment.SdkFieldPath {
				return false
			}

			return true
		}
	default:
		panic(fmt.Sprintf("unimplemented: field rename for mapping type %q", string(first.Type)))
	}

	return false
}

func modelDefinitionsMatch(t *testing.T, actual *map[string]resourcemanager.TerraformSchemaModelDefinition, expected map[string]resourcemanager.TerraformSchemaModelDefinition) {
	if actual == nil {
		t.Fatalf("actual was nil")
	}
	if len(*actual) != len(expected) {
		t.Fatalf("actual had %d models but expected had %d models", len(*actual), len(expected))
	}

	for key, firstVal := range *actual {
		secondVal, ok := expected[key]
		if !ok {
			t.Fatalf("key %q was present in actual but not expected", key)
		}

		if !fieldDefinitionsMatch(t, firstVal.Fields, secondVal.Fields) {
			t.Fatalf("field definitions didn't match")
		}
	}
}

func fieldDefinitionsMatch(t *testing.T, first map[string]resourcemanager.TerraformSchemaFieldDefinition, second map[string]resourcemanager.TerraformSchemaFieldDefinition) bool {
	// we can't use reflect.DeepEqual since there's pointers involved, so we'll do this the old-fashioned way
	if len(first) != len(second) {
		t.Fatalf("first had %d fields but second had %d fields", len(first), len(second))
		return false
	}

	for key, firstVal := range first {
		secondVal, ok := second[key]
		if !ok {
			t.Fatalf("key %q was present in first but not second", key)
			return false
		}

		if firstVal.Computed != secondVal.Computed {
			t.Fatalf("first computed %t != second computed %t", firstVal.Computed, secondVal.Computed)
		}
		if firstVal.ForceNew != secondVal.ForceNew {
			t.Fatalf("first forcenew %t != second forcenew %t", firstVal.ForceNew, secondVal.ForceNew)
		}
		if firstVal.HclName != secondVal.HclName {
			t.Fatalf("first hclName %q != second hclName %q", firstVal.HclName, secondVal.HclName)
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

func objectDefinitionsMatch(t *testing.T, first *resourcemanager.TerraformSchemaFieldObjectDefinition, second *resourcemanager.TerraformSchemaFieldObjectDefinition) bool {
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

// TODO - Put this, or equivalent, back when mappings are re-implemented
//func mappingsMatch(t *testing.T, first resourcemanager.TerraformSchemaFieldMappingDefinition, second resourcemanager.TerraformSchemaFieldMappingDefinition) bool {
//	if valueForNilableString(first.ResourceIdSegment) != valueForNilableString(second.ResourceIdSegment) {
//		t.Fatalf("ResourceIdSegment didn't match - first %q / second %q", valueForNilableString(first.ResourceIdSegment), valueForNilableString(second.ResourceIdSegment))
//		return false
//	}
//	if valueForNilableString(first.SdkPathForCreate) != valueForNilableString(second.SdkPathForCreate) {
//		t.Fatalf("SdkPathForCreate didn't match - first %q / second %q", valueForNilableString(first.SdkPathForCreate), valueForNilableString(second.SdkPathForCreate))
//		return false
//	}
//	if valueForNilableString(first.SdkPathForRead) != valueForNilableString(second.SdkPathForRead) {
//		t.Fatalf("SdkPathForRead didn't match - first %q / second %q", valueForNilableString(first.SdkPathForRead), valueForNilableString(second.SdkPathForRead))
//		return false
//	}
//	if valueForNilableString(first.SdkPathForUpdate) != valueForNilableString(second.SdkPathForUpdate) {
//		t.Fatalf("SdkPathForUpdate didn't match - first %q / second %q", valueForNilableString(first.SdkPathForUpdate), valueForNilableString(second.SdkPathForUpdate))
//		return false
//	}
//
//	return true
//}

func validatorsMatch(t *testing.T, first *resourcemanager.TerraformSchemaValidationDefinition, second *resourcemanager.TerraformSchemaValidationDefinition) bool {
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
	firstValues := strings.Join(stringifyValues(first.PossibleValues.Values), ", ")
	secondValues := strings.Join(stringifyValues(second.PossibleValues.Values), ", ")
	if !reflect.DeepEqual(firstValues, secondValues) {
		t.Fatalf("possible values didn't match - first %q / second %q", firstValues, secondValues)
		return false
	}

	return true
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
