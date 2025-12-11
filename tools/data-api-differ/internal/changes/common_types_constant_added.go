// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesConstantAdded{}

// CommonTypesConstantAdded defines information about a new CommonTypes Constant.
type CommonTypesConstantAdded struct {
	// ApiVersion specifies the name of the CommonTypes API Version which contains this Constant.
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
func (CommonTypesConstantAdded) IsBreaking() bool {
	return false
}
