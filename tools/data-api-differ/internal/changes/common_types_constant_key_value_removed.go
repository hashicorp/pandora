// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesConstantKeyValueRemoved{}

// CommonTypesConstantKeyValueRemoved specifies when a Key/Value combination is removed to an existing Constant.
type CommonTypesConstantKeyValueRemoved struct {
	// ApiVersion specifies the name of the API Version which contains this CommonTypes Constant.
	ApiVersion string

	// ConstantName specifies the name of the Constant which has been updated.
	ConstantName string

	// ConstantKey specifies the key for the Constant Key/Value which has been removed.
	ConstantKey string

	// ConstantValue specifies the value for the Constant Key/Value which has been removed
	ConstantValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesConstantKeyValueRemoved) IsBreaking() bool {
	return true
}
