// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelDiscriminatedParentTypeAdded{}

// ModelDiscriminatedParentTypeAdded defines that an existing Model is now
// a Discriminated Implementation of another Parent Type.
type ModelDiscriminatedParentTypeAdded struct {
	// ServiceName specifies the name of the Service which contains this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Model.
	ResourceName string

	// ModelName specifies the name of the Model which has become a Discriminated
	// Implementation.
	ModelName string

	// NewParentModelName specifies the name of the Parent Model that this Model is an
	// Implementation of.
	NewParentModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelDiscriminatedParentTypeAdded) IsBreaking() bool {
	// If an existing Model becomes a Discriminated Implementation then this is a breaking
	// change since we'll need to update the codebase to account for it.
	return true
}
