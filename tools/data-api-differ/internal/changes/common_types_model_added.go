// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesModelAdded{}

// CommonTypesModelAdded defines information about a new CommonTypes Model.
type CommonTypesModelAdded struct {
	// ApiVersion specifies the name of the CommonTypes API Version which contains this Model.
	ApiVersion string

	// ModelName specifies the name of the Model which has been added.
	ModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesModelAdded) IsBreaking() bool {
	return false
}
