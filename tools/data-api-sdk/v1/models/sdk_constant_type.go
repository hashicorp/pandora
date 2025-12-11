// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKConstantType defines the backing Type for a Constant used within the SDK.
// In the majority of cases these are String values (StringSDKConstantType) however
// both Float and Integer constants can exist too.
type SDKConstantType = string

const (
	// FloatSDKConstantType specifies that this represents a Float value.
	// This will be output in the Go SDK as a `float64`.
	FloatSDKConstantType SDKConstantType = "float"

	// IntegerSDKConstantType specifies that this represents an Integer value.
	// This will be output in the Go SDK as a `int64`.
	IntegerSDKConstantType SDKConstantType = "int"

	// StringSDKConstantType specifies that this represents a String value.
	// This will be output in the Go SDK as a `string`.
	StringSDKConstantType SDKConstantType = "string"
)
