package differ

import (
	"sort"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// stringifyObjectDefinition returns a human readable, string version of this Object Definition.
func (d differ) stringifyObjectDefinition(input resourcemanager.ApiObjectDefinition) (*string, error) {
	// NOTE: whilst the `.GolangTypeName()` method exists in the `resourcemanager` SDK, this won't
	// in the future so this method exists to have a single place to change in the future.
	return input.GolangTypeName(nil)
}

// uniqueConstantNames returns a unique, sorted list of Keys from initial and updated.
func (d differ) uniqueKeys(initial, updated map[string]string) []string {
	uniqueNames := make(map[string]struct{})
	for name := range initial {
		uniqueNames[name] = struct{}{}
	}
	for name := range updated {
		uniqueNames[name] = struct{}{}
	}

	output := make([]string, 0)
	for k := range uniqueNames {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}
