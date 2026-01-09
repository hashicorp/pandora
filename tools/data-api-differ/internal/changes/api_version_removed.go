// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ApiVersionRemoved{}

// ApiVersionRemoved defines information about an API Version which was previously
// supported for an existing Service but is no longer present.
type ApiVersionRemoved struct {
	// ServiceName specifies the name of this Service (e.g. `Compute`).
	ServiceName string

	// ApiVersion specifies the API Version (e.g. `2023-01-01-preview`).
	ApiVersion string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ApiVersionRemoved) IsBreaking() bool {
	return true
}
