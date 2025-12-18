// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// TerraformSchemaObjectDefinitionType defines the Type of Object Definition used in an TerraformSchemaObjectDefinition.
// Possible values include Simple types (boolean/integer/float/string), References (to a Constant or Model) and a
// List of the previous values.
type TerraformSchemaObjectDefinitionType string

// NOTE: we intentionally only have Terraform Schema fields (and specific CustomSchema types) here - meaning
// that we don't have RawObject/RawFile since we have no means of expressing them today.

// Simple Types

const (
	// BooleanTerraformSchemaObjectDefinitionType specifies that this represents a Boolean value.
	// This is output as a `bool` in Models and as `pluginsdk.TypeBool` within the Terraform Schema.
	BooleanTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Boolean"

	// DateTimeTerraformSchemaObjectDefinitionType specifies that this represents a DateTime value.
	// This is output as a `string` in Models and as `pluginsdk.TypeString` within the Schema.
	DateTimeTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "DateTime"

	// FloatTerraformSchemaObjectDefinitionType specifies that this represents a Float value.
	// This is output as a `float64` in Models and as `pluginsdk.TypeFloat` within the Schema.
	FloatTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Float"

	// IntegerTerraformSchemaObjectDefinitionType specifies that this represents an Integer value.
	// This is output as an `int64` in Models and as `pluginsdk.TypeInt` within the Schema.
	IntegerTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Integer"

	// StringTerraformSchemaObjectDefinitionType specifies that this represents a String value.
	// This is output as a `string` in Models and as `pluginsdk.TypeString` within the Schema.
	StringTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "String"
)

// Complex Types

const (
	// DictionaryTerraformSchemaObjectDefinitionType specifies that this represents a Dictionary value.
	// Note that a Dictionary must have an associated NestedItem which defines the Dictionary's Value type.
	// This is output as a `map[string]NestedObjectType` in Models and as `pluginsdk.TypeMap` within the Schema.
	DictionaryTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Dictionary"

	// ListTerraformSchemaObjectDefinitionType specifies that this represents a List value.
	// Note that a List must have an associated NestedItem which defines the List's Value type.
	// This is output as a `[]NestedObjectType` in Models and as `pluginsdk.TypeList` within the Schema.
	ListTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "List"

	// ReferenceTerraformSchemaObjectDefinitionType specifies that this represents a reference to another
	// Constant/Model.
	// This is output as a `NestedObjectType` in Models and as `pluginsdk.TypeList` (with MaxItems: 1) within
	// the Schema.
	ReferenceTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Reference"

	// SetTerraformSchemaObjectDefinitionType specifies that this represents a Set value.
	// Note that a Set must have an associated NestedItem which defines the Set's Value type.
	// This is output as a `[]NestedObjectType` in Models and as `pluginsdk.TypeSet` within the Schema.
	SetTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Set"
)

// CommonSchema Types

const (
	// EdgeZoneTerraformSchemaObjectDefinitionType specifies that this represents the Edge Zone Common Schema type.
	// This is output as a `[]NestedObjectType` in Models and as `commonschema.EdgeZoneXXX` within the Schema.
	EdgeZoneTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "EdgeZone"

	// LocationTerraformSchemaObjectDefinitionType specifies that this represents the Location Common Schema type.
	// This is output as a `string` in Models and as `commonschema.LocationXXX` within the Schema. // TODO: introduce a typealias for the model?
	LocationTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Location"

	// ResourceGroupTerraformSchemaObjectDefinitionType specifies that this represents the Resource Group Name Common
	// Schema type.
	// This is output as a `string` in Models and as `commonschema.ResourceGroupXXX` within the Schema. // TODO: introduce a typealias for the model?
	ResourceGroupTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "ResourceGroup"

	// TagsTerraformSchemaObjectDefinitionType specifies that this represents the Tags Common Schema type.
	// This is output as a `map[string]string` in Models and as `commonschema.TagsXXX` within the Schema. // TODO: introduce a typealias for the model?
	TagsTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Tags"

	// SystemAssignedIdentityTerraformSchemaObjectDefinitionType specifies that this represents the System Assigned Identity
	// Common Schema type.
	SystemAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "IdentitySystemAssigned"

	// SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that this represents the System AND User
	// Assigned Identity Common Schema type.
	SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "IdentitySystemAndUserAssigned"

	// SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that this represents the System OR User
	// Assigned Identity Common Schema type.
	SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "IdentitySystemOrUserAssigned"

	// UserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that this represents the User Assigned Identity
	// Common Schema type.
	UserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "IdentityUserAssigned"

	// ZoneTerraformSchemaObjectDefinitionType specifies that this represents the Singular Zone Common Schema type.
	ZoneTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Zone"

	// ZonesTerraformSchemaObjectDefinitionType specifies that this represents the Multiple Zones Common Schema type.
	ZonesTerraformSchemaObjectDefinitionType TerraformSchemaObjectDefinitionType = "Zones"
)
