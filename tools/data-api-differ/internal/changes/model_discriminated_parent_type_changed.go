// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelDiscriminatedParentTypeChanged{}

// ModelDiscriminatedParentTypeChanged defines that the Parent Model Name for this
// Discriminated Type has changed.
type ModelDiscriminatedParentTypeChanged struct {
	// ServiceName specifies the name of the Service which contains this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Model.
	ResourceName string

	// ModelName specifies the name of the Model which has become a Discriminated
	// Implementation.
	ModelName string

	// OldParentModelName specifies the name of the old Parent Model for this Model.
	OldParentModelName string

	// NewParentModelName specifies the name of the new Parent Model for this Model.
	NewParentModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelDiscriminatedParentTypeChanged) IsBreaking() bool {
	// If a Model changes Parent Type then this is a breaking change
	return true
}
