// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ConstantKeyValueChanged{}

// ConstantKeyValueChanged specifies when Constant Key has a new Value
type ConstantKeyValueChanged struct {
	// ServiceName specifies the name of the Service which contains this Constant.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Constant.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Constant.
	ResourceName string

	// ConstantName specifies the name of the Constant which has an updated value.
	ConstantName string

	// ConstantKey specifies the key within the Constant which has changed.
	ConstantKey string

	// OldConstantValue specifies the old Value for this Constant Key.
	OldConstantValue string

	// NewConstantValue specifies the new/updated Value for this Constant Key.
	NewConstantValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ConstantKeyValueChanged) IsBreaking() bool {
	return true
}
