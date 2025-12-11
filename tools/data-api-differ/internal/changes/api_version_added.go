// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ApiVersionAdded{}

// ApiVersionAdded defines information about a new API Version for an existing Service.
type ApiVersionAdded struct {
	// ServiceName specifies the name of this Service (e.g. `Compute`).
	ServiceName string

	// ApiVersion specifies the API Version (e.g. `2023-01-01-preview`).
	ApiVersion string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ApiVersionAdded) IsBreaking() bool {
	return false
}
