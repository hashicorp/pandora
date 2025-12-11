// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ApiResourceRemoved{}

// ApiResourceRemoved defines information about an API Resource which has been removed.
type ApiResourceRemoved struct {
	// ServiceName specifies the name of the Service which contained this API Resource.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contained this API Resource.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contained this Resource.
	ResourceName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ApiResourceRemoved) IsBreaking() bool {
	return true
}
