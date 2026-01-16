// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesConstantKeyValueChanged{}

// CommonTypesConstantKeyValueChanged specifies when Constant Key has a new Value
type CommonTypesConstantKeyValueChanged struct {
	// ApiVersion specifies the name of the API Version which contains this CommonTypes Constant.
	ApiVersion string

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
func (CommonTypesConstantKeyValueChanged) IsBreaking() bool {
	return true
}
