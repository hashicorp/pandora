// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesConstantKeyValueAdded{}

// CommonTypesConstantKeyValueAdded specifies when a new Key/Value combination is added to an existing CommonTypes Constant.
type CommonTypesConstantKeyValueAdded struct {
	// ApiVersion specifies the name of the API Version which contains this CommonTypes Constant.
	ApiVersion string

	// ConstantName specifies the name of the Constant which has been updated.
	ConstantName string

	// ConstantKey specifies the key for this new Constant Key/Value.
	ConstantKey string

	// ConstantValue specifies the value for this new Constant Key/Value.
	ConstantValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesConstantKeyValueAdded) IsBreaking() bool {
	return false
}
