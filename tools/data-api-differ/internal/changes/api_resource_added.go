// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ApiResourceAdded{}

// ApiResourceAdded defines information about an API Resource that has been added.
type ApiResourceAdded struct {
	// ServiceName specifies the name of the Service which contains this API Resource.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this API Resource.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Resource.
	ResourceName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ApiResourceAdded) IsBreaking() bool {
	return false
}
