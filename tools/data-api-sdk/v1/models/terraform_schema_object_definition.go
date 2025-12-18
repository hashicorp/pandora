// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaObjectDefinition is used to represent a Type used in the Terraform Schema.
// Some examples of this:
//  1. A Simple type (e.g. an integer/float/string).
//  2. A Complex type (e.g. the CommonSchema type `SystemAssignedIdentityTerraformSchemaObjectDefinitionType`).
//  3. A Reference to another Constant/Model (.
//  4. A List/Dictionary containing any of the above (e.g. a List<string>, a List<SomeConstant>,
//     a List<SomeModel>, a List<SystemAssignedIdentityTerraformSchemaObjectDefinitionType>.
type TerraformSchemaObjectDefinition struct {
	// NestedObject specifies any Nested Object housed within this TerraformSchemaObjectDefinition.
	// This is only specified when Type is set to DictionaryTerraformSchemaObjectDefinitionType,
	// ListTerraformSchemaObjectDefinitionType or SetTerraformSchemaObjectDefinitionType.
	NestedObject *TerraformSchemaObjectDefinition `json:"nestedObject"`

	// ReferenceName specifies the Constant or Model which is used as a Reference.
	// This is only specified when Type is set to ReferenceTerraformSchemaObjectDefinitionType.
	ReferenceName *string `json:"referenceName"`

	// Type specifies the Type of field that this is, for example a String or a Location.
	Type TerraformSchemaObjectDefinitionType `json:"type"`
}
