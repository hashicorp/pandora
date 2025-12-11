// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelRemoved{}

// ModelRemoved defines information about a Model which has been Removed.
type ModelRemoved struct {
	// ServiceName specifies the name of the Service which contained this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contained this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contained this Model.
	ResourceName string

	// ModelName specifies the name of the Model which has been removed.
	ModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelRemoved) IsBreaking() bool {
	return true
}
