// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKObjectDefinition is used to represent a Type used in the SDK. Some examples of this:
//  1. A Simple type (e.g. an integer/float/string).
//  2. A Complex type (e.g. the CommonSchema type `SystemAssignedIdentitySDKObjectDefinitionType`).
//  3. A Reference to another Constant/Model.
//  4. A List/Dictionary containing any of the above (e.g. a List<string>, a List<SomeConstant>,
//     a List<SomeModel>, a List<SystemAssignedIdentitySDKObjectDefinitionType>. These can be nested
//     repeatedly too, for example `Dictionary<string, Dictionary<string, Dictionary<string, int>>>>`.
type SDKObjectDefinition struct {
	// NestedItem specifies the shape of the object nested within this SDK Object Definition.
	// For example an SDKObjectDefinition with a Type of List may contain a NestedItem which
	// in turn has a Type of ReferenceSDKObjectDefinitionType and a ReferenceName set, to indicate
	// that a `[]TheReferenceName` should be assumed/output.
	NestedItem *SDKObjectDefinition `json:"nestedItem,omitempty"`

	// ReferenceName is the name of either the Constant or Model that should be output when Type
	// is set to `ReferenceSDKObjectDefinitionType`.
	ReferenceName *string `json:"referenceName,omitempty"`

	// ReferenceNameIsCommonType specifies whether the referenced Constant or Model is a common type
	ReferenceNameIsCommonType *bool `json:"referenceNameIsCommonType,omitempty"`

	// Type specifies the Type that represents this SDK Object Definition. This can be either a
	// Simple type (e.g. a String/Integer), a Reference to a Constant/Model or a more complex object
	// (e.g. a CommonSchema type [such as a SystemAssignedIdentity] - or a List/Dictionary).
	Type SDKObjectDefinitionType `json:"type"`

	// Nullable specifies that this type should be unset by sending `null` as the JSON value.
	Nullable bool `json:"nullable"`
}
