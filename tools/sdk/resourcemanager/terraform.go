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
	// metadata about the Terraform Data Sources which should be generated, including
	// any nested schemas.
	DataSources map[string]TerraformDataSourceDetails `json:"dataSources"`

	// Resources is a key (Resource Label) value (TerraformResourceDetails) pair of
	// metadata about the Terraform Resources which should be generated, including
	// any nested schemas.
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

type FieldBooleanEqualsMappingDefinition struct {
	// ConstantName (optionally) defines the name of the Constant where the ConstantValue
	// used as a BooleanEquals value can be found.
	ConstantName *string `json:"constantName,omitempty"`

	// ConstantValue (optionally) specifies the Value from the Constant defined in ConstantName
	// which this field must match for the result to be true, otherwise the result is false.
	ConstantValue *string `json:"constantValue,omitempty"`

	// Expression defines the literal value that the field should match, if it matches this is true
	// else this is false.
	Expression *string `json:"expression,omitempty"`
}

type FieldManualMappingDefinition struct {
	// MethodName specifies the name of the Manual mapping method used to map between the Schema and SDK Types
	MethodName string `json:"methodName"`
}

type FieldMappingDefinition struct {
	// Type specifies the MappingDefinitionType that is used for this field, such as DirectAssignment
	Type MappingDefinitionType `json:"type"`

	// From specifies information about the SchemaModel and Field that information should be parsed from.
	From FieldMappingFromDefinition `json:"from"`

	// To specifies information about the SdkModel and Field where the Schema value should be mapped onto.
	To FieldMappingToDefinition `json:"to"`

	// BooleanEquals contains additional metadata when Type is set to BooleanEquals
	BooleanEquals *FieldBooleanEqualsMappingDefinition `json:"booleanEquals,omitempty"`

	// Manual contains additional metadata when Type is set to Manual
	Manual *FieldManualMappingDefinition `json:"manual,omitempty"`
}

type FieldMappingFromDefinition struct {
	// SchemaFieldPath specifies the path to the field within SchemaModelName (e.g. `Foo` or `Foo.Bar`)
	// which this should be mapped from.
	SchemaFieldPath string `json:"schemaFieldPath"`

	// SchemaModelName specifies the name of the SchemaModel where this value should be mapped from.
	SchemaModelName string `json:"schemaModelName"`
}

type FieldMappingToDefinition struct {
	// SdkFieldPath specifies the Path to the Field within the SdkModel where the Schema Field
	// should be mapped onto.
	SdkFieldPath string `json:"sdkFieldPath"`

	// SdkModelName specifies the name of the SdkModel where this value should be mapped onto.
	SdkModelName string `json:"sdkModelName"`
}

type MappingDefinitionType string

const (
	BooleanEqualsMappingDefinitionType    MappingDefinitionType = "BooleanEquals"
	BooleanInvertMappingDefinitionType    MappingDefinitionType = "BooleanInvert"
	DirectAssignmentMappingDefinitionType MappingDefinitionType = "DirectAssignment"
	// TODO: more
)

type MappingDefinition struct {
	// Create defines the mappings used during the Create function.
	Create []FieldMappingDefinition `json:"create"`

	// Read defines the mappings used during the Read function.
	Read []FieldMappingDefinition `json:"read"`

	// Update (optionally) defines the mappings used during the Update function.
	Update *[]FieldMappingDefinition `json:"update,omitempty"`
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

	// Documentation specifies metadata used to generate the Documentation
	// for this Resource.
	Documentation ResourceDocumentationDefinition `json:"documentation"`

	// DisplayName is the human-readable/marketing name for this Resource,
	// for example `Resource Group` or `Virtual Machine`.
	DisplayName string `json:"displayName"`

	// Generate specifies if this Resource should be generated.
	Generate bool `json:"generate"`

	// GenerateModel controls whether the Schema Model(s) should be generated for this
	// Resource.
	GenerateModel bool `json:"generateModel"`

	// GenerateIdValidation controls whether the ID Validation function should be generated
	// for this Resource.
	GenerateIdValidation bool `json:"generateIdValidation"`

	// GenerateSchema controls whether the Schema should be generated for this
	// Resource.
	GenerateSchema bool `json:"generateSchema"`

	// Mappings defines the Mappings used for this Terraform Resource.
	Mappings MappingDefinition `json:"mappings"`

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

	// Tests defines the Terraform Configurations which should be used to test this Resource.
	Tests TerraformResourceTestsDefinition `json:"tests"`

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

	// Validation specifies the validation criteria for this field, for example a set of fixed values
	Validation *TerraformSchemaValidationDefinition `json:"validation,omitempty"`
}

type ResourceDocumentationDefinition struct {
	// Category is the category for this Terraform Resource which is used to
	// group this resource within the Terraform Registry.
	Category string `json:"category"`

	// Description is a description for this Terraform Resource which should
	// be output on the documentation page for this Resource.
	Description string `json:"description"`

	// ExampleUsageHcl is the HCL which should be output as an Example Usage
	// for this Resource. This should include all Required properties, and
	// ideally shows a basic fully functional example for this Resource.
	ExampleUsageHcl string `json:"exampleUsageHcl"`
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
	TerraformSchemaFieldTypeZone                          TerraformSchemaFieldType = "Zone"
	TerraformSchemaFieldTypeZones                         TerraformSchemaFieldType = "Zones"
)

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

	// PossibleValues describes the list of Possible Values allowed for this field.
	PossibleValues *TerraformSchemaValidationPossibleValuesDefinition `json:"possibleValues,omitempty"`
}

type TerraformSchemaValidationPossibleValuesDefinition struct {
	// Type specifies the Type of the Values field, for easier parsing.
	Type TerraformSchemaValidationPossibleValueType `json:"type"`

	// Values is the list of possible values allowed for this field, which can either be
	// a []int64, []float64 or []string depending on the value of `Type`.
	Values []interface{} `json:"values"`
}

type TerraformSchemaValidationPossibleValueType string

const (
	TerraformSchemaValidationPossibleValueTypeFloat  TerraformSchemaValidationPossibleValueType = "Float"
	TerraformSchemaValidationPossibleValueTypeInt    TerraformSchemaValidationPossibleValueType = "Int"
	TerraformSchemaValidationPossibleValueTypeString TerraformSchemaValidationPossibleValueType = "String"
)

type TerraformSchemaValidationType string

const (
	// TerraformSchemaValidationTypePossibleValues specifies that there's a fixed set of possible values
	// allowed for this field.
	TerraformSchemaValidationTypePossibleValues TerraformSchemaValidationType = "PossibleValues"

	// TODO: implement other types e.g. NoEmptyValues/Ranges
)

type TerraformSchemaFieldObjectDefinition struct {
	NestedObject *TerraformSchemaFieldObjectDefinition `json:"nestedObject,omitempty"`

	// ReferenceName is the name of the Reference associated with this ObjectDefinition.
	ReferenceName *string `json:"referenceName"`

	// Type specifies the Type of field that this is, for example a String or a Location.
	Type TerraformSchemaFieldType `json:"type"`
}

type TerraformResourceTestsDefinition struct {
	// BasicConfiguration is the most basic Terraform Configuration for this Resource
	// this should be only the Required fields necessary to provision this Resource.
	BasicConfiguration string `json:"basicConfiguration"`

	// RequiresImportConfiguration is a Terraform Configuration based on BasicConfiguration
	// that exists to confirm the ResourcesImport functionality works as expected.
	RequiresImportConfiguration string `json:"requiresImportConfiguration"`

	// CompleteConfiguration is an optional Terraform Configuration defining all of the possible
	// fields which can be set for this Resource. If the Resource only contains Required fields
	// then this field is superflurous and can be removed (since the Basic test covers this).
	CompleteConfiguration *string `json:"completeConfiguration,omitempty"`

	// Generate specifies whether the Tests should be generated or not.
	Generate bool `json:"generate"`

	// OtherTests is a map of key (TestName) to value (a slice of Test Configurations) which
	// should be output as Acceptance Tests.
	OtherTests map[string][]string `json:"otherTests"`

	// TemplateConfiguration is an optional Terraform Configuration which should be used
	// as the Template for each of the Tests defined above, which should include any parent
	// resources required in the Tests.
	TemplateConfiguration *string `json:"templateConfiguration,omitempty"`
}
