// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKConstant defines a Constant used in the SDK.
// The Type field specified whether this Constant is an Integer, Float or a String.
// The Values field specifies a map of Keys (intended to be used as the Constant/Display
// Name) to the Values - which are all output as Strings.
type SDKConstant struct {
	// Type specifies the type of values provided by this Constant.
	// This can be either a Float value (output as `float64`), an Integer (output as
	// `int64`) or a String (output as `string`).
	Type SDKConstantType `json:"type"`

	// Values specifies a mapping of Constant Name (key) to the Stringified Value.
	// This value is stringified to ensure the same precision is output/used everywhere for
	// float values.
	// NOTE: the Constant Name is a valid Identifier.
	Values map[string]string `json:"values"`
}
