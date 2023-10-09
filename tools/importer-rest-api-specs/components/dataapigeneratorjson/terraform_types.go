package dataapigeneratorjson

type TerraformSchemaFieldType string

const (
	TerraformSchemaFieldTypeBoolean    TerraformSchemaFieldType = "Boolean"
	TerraformSchemaFieldTypeDateTime   TerraformSchemaFieldType = "DateTime"
	TerraformSchemaFieldTypeDictionary TerraformSchemaFieldType = "Dictionary"
	TerraformSchemaFieldTypeFloat      TerraformSchemaFieldType = "Float"
	TerraformSchemaFieldTypeInteger    TerraformSchemaFieldType = "Integer"
	TerraformSchemaFieldTypeList       TerraformSchemaFieldType = "List"
	TerraformSchemaFieldTypeReference  TerraformSchemaFieldType = "Reference"
	TerraformSchemaFieldTypeSet        TerraformSchemaFieldType = "Set"
	TerraformSchemaFieldTypeString     TerraformSchemaFieldType = "String"
	// NOTE: we intentionally only have Terraform Schema fields (and specific CustomSchema types) here - meaning
	// that we don't have RawObject/RawFile since we have no means of expressing them today.

	TerraformSchemaFieldTypeEdgeZone                      TerraformSchemaFieldType = "EdgeZone"
	TerraformSchemaFieldTypeIdentitySystemAssigned        TerraformSchemaFieldType = "IdentitySystemAssigned"
	TerraformSchemaFieldTypeIdentitySystemAndUserAssigned TerraformSchemaFieldType = "IdentitySystemAndUserAssigned"
	TerraformSchemaFieldTypeIdentitySystemOrUserAssigned  TerraformSchemaFieldType = "IdentitySystemOrUserAssigned"
	TerraformSchemaFieldTypeIdentityUserAssigned          TerraformSchemaFieldType = "IdentityUserAssigned"
	TerraformSchemaFieldTypeLocation                      TerraformSchemaFieldType = "Location"
	TerraformSchemaFieldTypeResourceGroup                 TerraformSchemaFieldType = "ResourceGroup"
	TerraformSchemaFieldTypeTags                          TerraformSchemaFieldType = "Tags"
	TerraformSchemaFieldTypeSku                           TerraformSchemaFieldType = "Sku"
	TerraformSchemaFieldTypeZone                          TerraformSchemaFieldType = "Zone"
	TerraformSchemaFieldTypeZones                         TerraformSchemaFieldType = "Zones"
)
