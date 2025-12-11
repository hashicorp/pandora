// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelAdded{}

// ModelAdded defines information about a new Model.
type ModelAdded struct {
	// ServiceName specifies the name of the Service which contains this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Model.
	ResourceName string

	// ModelName specifies the name of the Model which has been added.
	ModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelAdded) IsBreaking() bool {
	return false
}
