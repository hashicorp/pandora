// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKOperationOptionObjectDefinition defines the shape of an SDKOperationOption.
// This can either represent a Simple type (e.g. bool/integer/float/string), a Reference
// to a Constant or a List of one of the previous items (e.g. `List<string>`).
type SDKOperationOptionObjectDefinition struct {
	// NestedItem specifies the shape of any Nested object for this Object Definition.
	NestedItem *SDKOperationOptionObjectDefinition `json:"nestedItem,omitempty"`

	// ReferenceName specifies the name of the Constant when Type is set to
	// ReferenceSDKOperationOptionObjectDefinitionType.
	ReferenceName *string `json:"referenceName,omitempty"`

	// Type specifies the Type of Object that represents this Object Definition.
	// This can either be a Simple type (e.g. bool/integer/float/string), a Reference
	// to a Constant or a List of one of the previous items (e.g. `List<string>`).
	Type SDKOperationOptionObjectDefinitionType `json:"type"`
}
