// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ConstantKeyValueAdded{}

// ConstantKeyValueAdded specifies when a new Key/Value combination is added to an existing Constant.
type ConstantKeyValueAdded struct {
	// ServiceName specifies the name of the Service which contains this Constant.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Constant.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Constant.
	ResourceName string

	// ConstantName specifies the name of the Constant which has been updated.
	ConstantName string

	// ConstantKey specifies the key for this new Constant Key/Value.
	ConstantKey string

	// ConstantValue specifies the value for this new Constant Key/Value.
	ConstantValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ConstantKeyValueAdded) IsBreaking() bool {
	return false
}
