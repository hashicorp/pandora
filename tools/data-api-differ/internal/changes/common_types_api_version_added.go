// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesApiVersionAdded{}

// CommonTypesApiVersionAdded defines information about a new API Version for CommonTypes.
type CommonTypesApiVersionAdded struct {
	// ApiVersion specifies the API Version (e.g. `2023-01-01-preview`) for which CommonTypes have been added.
	ApiVersion string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesApiVersionAdded) IsBreaking() bool {
	return false
}
