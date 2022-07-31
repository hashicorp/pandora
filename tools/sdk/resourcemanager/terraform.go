package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type TerraformClient struct {
	Client
}

func (c TerraformClient) Get(input ServiceDetails) (*TerraformDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.TerraformUri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response TerraformDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type TerraformDetails struct {
	// DataSources is a key (Resource Label) value (TerraformDataSourceDetails) pair of
	// metadata about the Terraform Data Sources which should be generated.
	DataSources map[string]TerraformDataSourceDetails `json:"dataSources"`

	// Resources is a key (Resource Label) value (TerraformResourceDetails) pair of
	// metadata about the Terraform Resources which should be generated.
	Resources map[string]TerraformResourceDetails `json:"resources"`
}

type TerraformDataSourceDetails struct {
	// ApiVersion specifies the version of the Api which should be used for
	// this Data Source.
	ApiVersion string `json:"apiVersion"`

	// Generate specifies if this Data Source should be generated.
	Generate bool `json:"generate"`

	// PluralDetails specifies the metadata for the Plural version of this Data Source
	// A Singular Data Source returns information about exactly 1 existing Resource, whereas
	// a Plural Data Source returns information about 1 or more existing Resources.
	PluralDetails *TerraformDataSourceTypeDetails `json:"plural"`

	// SingularDetails specifies the metadata for the Singular version of this Data Source
	// A Singular Data Source returns information about exactly 1 existing Resource, whereas
	// a Plural Data Source returns information about 1 or more existing Resources.
	SingularDetails *TerraformDataSourceTypeDetails `json:"singular"`

	// TODO: populate this
}

type TerraformDataSourceTypeDetails struct {
	// Description is a human-friendly description for this Data Source Type.
	Description string `json:"description"`

	// ExampleUsageHcl is the HCL which should be output as the Example Usage for this Data Source Type.
	ExampleUsageHcl string `json:"exampleUsageHcl"`

	// Generate specifies whether this Data Source Type should be generated this allows just the
	// Singular Data Source or the Plural Data Source to be generated as required.
	Generate bool `json:"generate"`

	// GenerateSchema specifies whether the Typed Model should be generated for this Data Source Type.
	GenerateModel bool `json:"generateModel"`

	// GenerateSchema specifies whether the Schema should be generated for this Data Source Type.
	GenerateSchema bool `json:"generateSchema"`

	// MethodDefinition specifies the SDK Method which should be used for this Data Source Type.
	MethodDefinition MethodDefinition `json:"methodDefinition"`

	// ResourceLabel is the label for this Data Source Type without the Provider Prefix
	// (e.g. `resource_group` rather than `azurerm_resource_group`).
	ResourceLabel string `json:"resourceLabel"`
}

type TerraformResourceDetails struct {
	// ApiVersion specifies the version of the Api which should be used for
	// this resource.
	ApiVersion string `json:"apiVersion"`

	// CreateMethod describes the method within the SDK Package that should
	// be used to create this resource in Terraform.
	CreateMethod MethodDefinition `json:"createMethod"`

	// DeleteMethod describes the method within the SDK Package that should
	// be used to delete this resource in Terraform.
	DeleteMethod MethodDefinition `json:"deleteMethod"`

	// DisplayName is the human-readable/marketing name for this Resource,
	// for example `Resource Group` or `Virtual Machine`.
	DisplayName string `json:"displayName"`

	// Generate specifies if this Resource should be generated.
	Generate bool `json:"generate"`

	// GenerateSchema controls whether the Schema should be generated for this
	// Resource.
	GenerateSchema bool `json:"generateSchema"`

	// GenerateIdValidation controls whether the ID Validation function should be generated
	// for this Resource.
	GenerateIdValidation bool `json:"generateIdValidation"`

	// ReadMethod describes the method within the SDK Package that should
	// be used to retrieve information about this resource in Terraform.
	ReadMethod MethodDefinition `json:"readMethod"`

	// Resource specifies the Resource within this API Version within the Service where
	// the details for this Resource can be found.
	Resource string `json:"resource"`

	// ResourceIdName specifies the name of the Resource ID type used for this Resource.
	ResourceIdName string `json:"resourceIdName"`

	// ResourceName specifies the name of this Resource (which can be used as a Go Type Name).
	ResourceName string `json:"resourceName"`

	// SchemaModelName specifies the name of the Schema model for this Terraform Resource
	SchemaModelName string `json:"schemaModelName"`

	// SchemaModels is a Map of ModelName -> TerraformSchemaModelDefinition defining the
	// Terraform Schema Models used in this Resource, including mappings to the SDK Models.
	SchemaModels map[string]TerraformSchemaModelDefinition `json:"schemaModels"`

	// UpdateMethod optionally describes the method within the SDK Package that should
	// be used to update this resource in Terraform.
	UpdateMethod *MethodDefinition `json:"updateMethod,omitempty"`
}

type MethodDefinition struct {
	// Generate specifies whether this function should be generated for this Resource.
	Generate bool `json:"generate"`

	// MethodName specifies the name of the SDK method whicn should be used.
	MethodName string `json:"methodName"`

	// TimeoutInMinutes specifies the Terraform Timeout for this Resource (in minutes)
	TimeoutInMinutes int `json:"timeoutInMinutes"`
}

type TerraformSchemaFieldDefinition struct {
	// ObjectDefinition specifies what this field is, for example a String or a List of a Model.
	ObjectDefinition TerraformSchemaFieldObjectDefinition `json:"objectDefinition"`

	// Computed specifies whether this field is Computed, meaning that the API defines a
	// value for this field.
	Computed bool `json:"computed"`

	// ForceNew specifies whether this field is ForceNew, meaning that changes to this field
	// will require the recreation of this Resource.
	ForceNew bool `json:"forceNew"`

	// HclName is the name which should be used for this field in HCL
	HclName string `json:"hclName"`

	// Optional specifies whether this field is Optional, e.g. it can be omitted.
	Optional bool `json:"optional"`

	// Requires specifies whether this field is Required, e.g. it must be specified.
	Required bool `json:"required"`

	// Documentation specifies the Documentation available for this field
	Documentation TerraformSchemaDocumentationDefinition `json:"documentation"`

	// Mappings specifies the Mapping associated with this field, namely where does the value
	// for this field get used and where does it's value get retrieved from.
	Mappings TerraformSchemaFieldMappingDefinition `json:"mappings"`

	// Validation specifies the validation criteria for this field, for example a set of fixed values
	Validation *TerraformSchemaValidationDefinition `json:"validation,omitempty"`
}

type TerraformSchemaFieldType string

const (
	TerraformSchemaFieldTypeBoolean   TerraformSchemaFieldType = "Boolean"
	TerraformSchemaFieldTypeDateTime  TerraformSchemaFieldType = "DateTime"
	TerraformSchemaFieldTypeFloat     TerraformSchemaFieldType = "Float"
	TerraformSchemaFieldTypeInteger   TerraformSchemaFieldType = "Integer"
	TerraformSchemaFieldTypeList      TerraformSchemaFieldType = "List"
	TerraformSchemaFieldTypeReference TerraformSchemaFieldType = "Reference"
	TerraformSchemaFieldTypeSet       TerraformSchemaFieldType = "Set"
	TerraformSchemaFieldTypeString    TerraformSchemaFieldType = "String"

	TerraformSchemaFieldTypeEdgeZone                      TerraformSchemaFieldType = "EdgeZone"
	TerraformSchemaFieldTypeIdentitySystemAssigned        TerraformSchemaFieldType = "IdentitySystemAssigned"
	TerraformSchemaFieldTypeIdentitySystemAndUserAssigned TerraformSchemaFieldType = "IdentitySystemAndUserAssigned"
	TerraformSchemaFieldTypeIdentitySystemOrUserAssigned  TerraformSchemaFieldType = "IdentitySystemOrUserAssigned"
	TerraformSchemaFieldTypeIdentityUserAssigned          TerraformSchemaFieldType = "IdentityUserAssigned"
	TerraformSchemaFieldTypeLocation                      TerraformSchemaFieldType = "Location"
	TerraformSchemaFieldTypeResourceGroup                 TerraformSchemaFieldType = "ResourceGroup"
	TerraformSchemaFieldTypeTags                          TerraformSchemaFieldType = "Tags"
	TerraformSchemaFieldTypeZone                          TerraformSchemaFieldType = "Zone"
	TerraformSchemaFieldTypeZones                         TerraformSchemaFieldType = "Zones"
)

type TerraformSchemaFieldMappingDefinition struct {
	// ResourceIdSegment specifies the name of the Resource ID Segment which this Schema
	// Field maps both to and from.
	ResourceIdSegment *string `json:"resourceIdSegment"`

	// SdkPathForCreate (optionally) specifies the path on the SDK Model used for the Create
	// function where this field should be specified.
	SdkPathForCreate *string `json:"sdkPathForCreate"`

	// SdkPathForRead (optionally) specifies the path on the SDK Model used for the Read
	// function where this field should be specified.
	SdkPathForRead *string `json:"sdkPathForRead"`

	// SdkPathForUpdate (optionally) specifies the path on the SDK Model used for the
	// Update function where this field should be specified.
	SdkPathForUpdate *string `json:"sdkPathForUpdate"`
}

type TerraformSchemaModelDefinition struct {
	// Fields is a Map of Field Name -> TerraformSchemaFieldDefinition defining the fields
	// for this Terraform Schema Model.
	Fields map[string]TerraformSchemaFieldDefinition `json:"fields"`
}

type TerraformSchemaDocumentationDefinition struct {
	// Markdown is the Documentation for this field in the Markdown format.
	Markdown string `json:"markdown"`
}

type TerraformSchemaValidationDefinition struct {
	// Type specifies the type of validation used for this field
	Type TerraformSchemaValidationType `json:"type"`

	// PossibleValues is an (optional) list of Possible Values allowed for this field.
	PossibleValues *[]string `json:"possibleValues,omitempty"`
}

type TerraformSchemaValidationType string

const (
	TerraformSchemaValidationTypeFixedValues  TerraformSchemaValidationType = "FixedValues"
	TerraformSchemaValidationTypeNoEmptyValue TerraformSchemaValidationType = "NoEmptyValue"
)

type TerraformSchemaFieldObjectDefinition struct {
	NestedObject *TerraformSchemaFieldObjectDefinition `json:"nestedObject,omitempty"`

	// ReferenceName is the name of the Reference associated with this ObjectDefinition.
	ReferenceName *string `json:"referenceName"`

	// Type specifies the Type of field that this is, for example a String or a Location.
	Type TerraformSchemaFieldType `json:"type"`
}
