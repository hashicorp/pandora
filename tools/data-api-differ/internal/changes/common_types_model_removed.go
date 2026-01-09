// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesModelRemoved{}

// CommonTypesModelRemoved defines information about a CommonTypes Model which has been Removed.
type CommonTypesModelRemoved struct {
	// ApiVersion specifies the name of the CommonTypes API Version which contained this Model.
	ApiVersion string

	// ModelName specifies the name of the Model which has been removed.
	ModelName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesModelRemoved) IsBreaking() bool {
	return true
}
