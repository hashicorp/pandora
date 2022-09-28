package mappings

import (
	"fmt"
	"reflect"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: tests

type mappingGrouping struct {
	fromTypeName string
	toTypeName   string
	mappings     []resourcemanager.FieldMappingDefinition
}

func groupMappings(input []resourcemanager.FieldMappingDefinition) []mappingGrouping {
	// group the mappings based on the name of the FromSchemaModel and the name of the ToSdkModel
	wip := make(map[string]mappingGrouping)
	for _, v := range input {
		key := fmt.Sprintf("%s-%s", v.DirectAssignment.SchemaModelName, v.DirectAssignment.SdkModelName)
		existing, ok := wip[key]
		if !ok {
			existing = mappingGrouping{
				fromTypeName: v.DirectAssignment.SchemaModelName,
				toTypeName:   v.DirectAssignment.SdkModelName,
				mappings:     make([]resourcemanager.FieldMappingDefinition, 0),
			}
		}
		existing.mappings = append(existing.mappings, v)
		wip[key] = existing
	}

	out := make([]mappingGrouping, 0)
	for _, v := range wip {
		out = append(out, v)
	}
	return out
}

func findMappingBetween(mappings []resourcemanager.FieldMappingDefinition, other resourcemanager.FieldMappingDefinition) *resourcemanager.FieldMappingDefinition {
	for _, v := range mappings {
		if v.Type == other.Type {
			if v.DirectAssignment != nil && other.DirectAssignment != nil {
				if reflect.DeepEqual(*v.DirectAssignment, *other.DirectAssignment) {
					return &v
				}
			}
			if v.Manual != nil && other.Manual != nil {
				if reflect.DeepEqual(*v.Manual, *other.Manual) {
					return &v
				}
			}
		}
	}

	return nil
}

func mappingsAreTheSame(first resourcemanager.FieldMappingDefinition, second *resourcemanager.FieldMappingDefinition) bool {
	if first.Type != second.Type {
		return false
	}

	// TODO: check the nested objects too
	return true
}

func singleFieldNameFromFieldPath(fieldPath string) (*string, error) {
	if strings.ContainsAny(fieldPath, ".") {
		return nil, fmt.Errorf("TODO: implement support for nested field mappings (e.g. `Foo.Bar`)")
	}

	return &fieldPath, nil
}

func sortAndOutputMappingFunctions(input map[string]string) string {
	methodNames := make([]string, 0)
	for k := range input {
		methodNames = append(methodNames, k)
	}
	sort.Strings(methodNames)

	lines := make([]string, 0)
	for _, key := range methodNames {
		method := input[key]
		lines = append(lines, method)
	}

	out := strings.Join(lines, "\n")
	return out
}
