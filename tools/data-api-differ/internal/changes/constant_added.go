// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ConstantAdded{}

// ConstantAdded defines information about a new Constant.
type ConstantAdded struct {
	// ServiceName specifies the name of the Service which contains this Constant.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Constant.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Constant.
	ResourceName string

	// ConstantName specifies the name of the Constant which has been added.
	ConstantName string

	// ConstantType specifies the type of Constant (e.g. Int/String) that this is.
	ConstantType string

	// KeysAndValues specifies the Keys and Values for the Constant which has been added.
	KeysAndValues map[string]string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ConstantAdded) IsBreaking() bool {
	return false
}
