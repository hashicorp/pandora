// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaObjectDefinition describes the Type used in a Terraform Schema field.
type TerraformSchemaObjectDefinition struct {
	// NestedItem defines any Nested Object Definition for this object Definition
	// This exists when Type is a Dictionary, List or a Set (as the Value Type)
	NestedItem *TerraformSchemaObjectDefinition `json:"nestedItem,omitempty"`

	// ReferenceName is the name of the Reference associated with this TerraformSchemaObjectDefinition.
	// This exists when Type is set to ReferenceTerraformSchemaObjectDefinitionType.
	ReferenceName *string `json:"referenceName"`

	// Type specifies the Type that this represents, for example a String or a Location.
	Type TerraformSchemaObjectDefinitionType `json:"type"`
}

// TerraformSchemaObjectDefinitionType specifies the Type of Object that is used in the Terraform Schema.
//
// Note: these types are intentionally separate from the Object Definition Types used in the (Go) SDK
// to allow for higher fidelity - and more consistency - when outputting the Terraform Schema.
//
// Whilst in some cases these may be directly compatible (e.g. a String value) in others these can
// require additional transformation - as such the Terraform Generator defines how to map to/from
// the ObjectDefinitionType used in the Go SDK and the TerraformSchemaObjectDefinitionType used in
// the Terraform Schema (both in the Typed Model and the Terraform Schema `Attributes` and
// `Arguments` functions).
type TerraformSchemaObjectDefinitionType string

const (
	// BooleanTerraformSchemaObjectDefinitionType specifies that the Type represents a Boolean.
	BooleanTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Boolean"

	// DateTimeTerraformSchemaObjectDefinitionType specifies that the Type represents a DateTime.
	DateTimeTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "DateTime"

	// DictionaryTerraformSchemaObjectDefinitionType specifies that the Type represents a Dictionary
	// Dictionaries use a String value for a Key and the Value Type will be defined as a NestedItem
	// within the TerraformSchemaObjectDefinition.
	DictionaryTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Dictionary"

	// EdgeZoneTerraformSchemaObjectDefinitionType specifies that the Type represents an Edge Zone.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	EdgeZoneTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "EdgeZone"

	// LocationTerraformSchemaObjectDefinitionType specifies that the Type represents a Location.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	LocationTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Location"

	// FloatTerraformSchemaObjectDefinitionType specifies that the Type represents a Float.
	FloatTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Float"

	// IntegerTerraformSchemaObjectDefinitionType specifies that the Type represents an Integer.
	IntegerTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Integer"

	// ListTerraformSchemaObjectDefinitionType specifies that the Type represents a List where the Value
	// Type will be defined as a NestedItem within the TerraformSchemaObjectDefinition.
	ListTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "List"

	// ReferenceTerraformSchemaObjectDefinitionType specifies that the Type represents a Reference to
	// either a Constant or a Model.
	ReferenceTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Reference"

	// ResourceGroupTerraformSchemaObjectDefinitionType specifies that the Type represents a Resource Group Name.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	ResourceGroupTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "ResourceGroup"

	// SetTerraformSchemaObjectDefinitionType specifies that the Type is a Set where the Value
	// Type will be defined as a NestedItem within the TerraformSchemaObjectDefinition.
	SetTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Set"

	// StringTerraformSchemaObjectDefinitionType specifies that the Type represents a String.
	StringTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "String"

	// SystemAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a System Assigned (Managed) Identity.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SystemAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "SystemAssignedIdentity"

	// SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a System AND User Assigned Identity
	// supporting both a System Assigned (Managed) Identity, a User Assigned Identity - AND a combination of the two used together.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "SystemAndUserAssignedIdentity"

	// SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a System OR User Assigned Identity
	// supporting either a System Assigned (Managed) Identity or a User Assigned Identity - but not both.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "SystemOrUserAssignedIdentity"

	// TagsTerraformSchemaObjectDefinitionType specifies that the Type represents Tags
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	TagsTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Tags"

	// UserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a User Assigned Identity.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	UserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "UserAssignedIdentity"

	// ZoneTerraformSchemaObjectDefinitionType specifies that the Type represents a single (Availability) Zone.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	ZoneTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Zone"

	// ZonesTerraformSchemaObjectDefinitionType specifies that the Type represents multiple (Availability) Zones.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	ZonesTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Zones"
)
