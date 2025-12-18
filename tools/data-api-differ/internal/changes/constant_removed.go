// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ConstantRemoved{}

// ConstantRemoved defines information about a Constant which has been removed.
type ConstantRemoved struct {
	// ServiceName specifies the name of the Service which contained this Constant.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contained this Constant.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contained this Constant.
	ResourceName string

	// ConstantName specifies the name of the Constant which has been removed.
	ConstantName string

	// ConstantType specifies the type of Constant (e.g. Int/String) that this is.
	ConstantType string

	// KeysAndValues specifies the Keys and Values for the Constant which has been removed.
	KeysAndValues map[string]string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ConstantRemoved) IsBreaking() bool {
	return true
}
