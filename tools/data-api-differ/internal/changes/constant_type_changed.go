// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ConstantTypeChanged{}

// ConstantTypeChanged specifies when a Constant has changed Type (e.g. `int` -> `string`)
type ConstantTypeChanged struct {
	// ServiceName specifies the name of the Service which contains this Constant.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Constant.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Constant.
	ResourceName string

	// ConstantName specifies the name of the Constant which has changed.
	ConstantName string

	// OldType specifies the old type value for this Constant
	OldType string

	// NewType specifies the new/updated type value for this Constant
	NewType string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (c ConstantTypeChanged) IsBreaking() bool {
	// If a constant changes type, this is going to require code changes to account for this
	return true
}
