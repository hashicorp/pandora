// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelDiscriminatedParentTypeRemoved{}

// ModelDiscriminatedParentTypeRemoved defines that an existing Model was a Discriminated Type
// (i.e. had a Parent Type) but no longer does.
type ModelDiscriminatedParentTypeRemoved struct {
	// ServiceName specifies the name of the Service which contains this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Model.
	ResourceName string

	// ModelName specifies the name of the Model which has become a Discriminated
	// Implementation.
	ModelName string

	// OldParentModelName specifies the name of the Parent Model that this Model was an
	// Implementation of.
	OldParentModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelDiscriminatedParentTypeRemoved) IsBreaking() bool {
	// If an existing Model is no longer a Discriminated Implementation then this is a
	// breaking change since we'll need to update the codebase to account for it.
	return true
}
