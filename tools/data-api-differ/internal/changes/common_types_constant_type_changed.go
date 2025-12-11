// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesConstantTypeChanged{}

// CommonTypesConstantTypeChanged specifies when a CommonTypes Constant has changed Type (e.g. `int` -> `string`)
type CommonTypesConstantTypeChanged struct {
	// ApiVersion specifies the name of the API Version which contains this CommonTypes Constant.
	ApiVersion string

	// ConstantName specifies the name of the Constant which has changed.
	ConstantName string

	// OldType specifies the old type value for this Constant
	OldType string

	// NewType specifies the new/updated type value for this Constant
	NewType string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (c CommonTypesConstantTypeChanged) IsBreaking() bool {
	// If a constant changes type, this is going to require code changes to account for this
	return true
}
