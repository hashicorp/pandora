package generator

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func golangTypeNameForObjectDefinition(input resourcemanager.ApiObjectDefinition) (*string, error) {
	// NOTE: since all the models are generated into the same Namespace in the Go SDK
	// we don't need to pass the Package Name in (this is instead used in the TF Generator
	// where we're instead importing items from the Go SDK).
	return input.GolangTypeName(nil)
}

func topLevelObjectDefinition(input resourcemanager.ApiObjectDefinition) resourcemanager.ApiObjectDefinition {
	if input.NestedItem != nil {
		return topLevelObjectDefinition(*input.NestedItem)
	}

	return input
}
