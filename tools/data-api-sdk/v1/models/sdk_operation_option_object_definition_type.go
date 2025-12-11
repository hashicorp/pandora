// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKOperationOptionObjectDefinitionType defines the Type of Object Definition used in an SDKOperationOption.
// Possible values include Simple types (boolean/integer/float/string), References (to a Constant) and a
// List of the previous values.
type SDKOperationOptionObjectDefinitionType string

const (
	// BooleanSDKOperationOptionObjectDefinitionType defines that the payload is a Boolean.
	// This will be output as the Go type `bool`.
	BooleanSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "Boolean"

	// CSVSDKOperationOptionObjectDefinitionType defines that the payload is a list of Comma Separated Values.
	// This will be output as the Go type `string`.
	CSVSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "Csv"

	// IntegerSDKOperationOptionObjectDefinitionType defines that the payload is an Integer.
	// This will be output as the Go type `int64`.
	IntegerSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "Integer"

	// FloatSDKOperationOptionObjectDefinitionType defines that the payload is a Float.
	// This will be output as the Go type `float64`.
	FloatSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "Float"

	// ListSDKOperationOptionObjectDefinitionType defines that the payload is a List.
	// A List must always contain a Nested Item (stating what it's a List of).
	// This will be output as a Go slice (e.g. `[]string` for a List<string>`).
	ListSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "List"

	// ReferenceSDKOperationOptionObjectDefinitionType defines that the payload is a reference to a Constant.
	// This will be output as the associated Reference name (e.g. `AvailableSkusConstant`).
	ReferenceSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "Reference"

	// StringSDKOperationOptionObjectDefinitionType defines that the payload is a String.
	// This will be output as the Go type `string`.
	StringSDKOperationOptionObjectDefinitionType SDKOperationOptionObjectDefinitionType = "String"
)
