// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesConstantRemoved{}

// CommonTypesConstantRemoved defines information about a new CommonTypes Constant.
type CommonTypesConstantRemoved struct {
	// ApiVersion specifies the name of the CommonTypes API Version which contains this Constant.
	ApiVersion string

	// ConstantName specifies the name of the Constant which has been removed.
	ConstantName string

	// ConstantType specifies the type of Constant (e.g. Int/String) that this is.
	ConstantType string

	// KeysAndValues specifies the Keys and Values for the Constant which has been removed.
	KeysAndValues map[string]string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesConstantRemoved) IsBreaking() bool {
	return true
}
