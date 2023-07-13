package generator

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func golangTypeNameForObjectDefinition(input resourcemanager.ApiObjectDefinition, commonPackagePath *string) (*string, error) {
	// NOTE: The models can be generated into the same Namespace in the Go SDK, or in a "common" namespace,
	// so we'll determine that based on the object definition from the API. Where the same namespace is used,
	// we don't need to pass the Package Name in (this is instead used in the TF Generator where we're importing
	// types from the Go SDK).
	if input.ReferenceIsCommonType != nil && *input.ReferenceIsCommonType {
		return input.GolangTypeName(commonPackagePath)
	}
	return input.GolangTypeName(nil)
}

func topLevelObjectDefinition(input resourcemanager.ApiObjectDefinition) resourcemanager.ApiObjectDefinition {
	if input.NestedItem != nil {
		return topLevelObjectDefinition(*input.NestedItem)
	}

	return input
}
