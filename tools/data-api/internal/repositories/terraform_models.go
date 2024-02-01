package repositories

type TerraformDetails struct {
	DataSources map[string]TerraformDataSourceDetails
	Resources   map[string]TerraformResourceDetails
}

type TerraformDataSourceDetails struct {
	Description      string
	ExampleUsageHcl  string
	Generate         bool
	GenerateModel    bool
	GenerateSchema   bool
	MethodDefinition MethodDefinition
	ResourceLabel    string
}

type TerraformResourceDetails struct {
	ApiVersion           string
	CreateMethod         MethodDefinition
	DeleteMethod         MethodDefinition
	Documentation        ResourceDocumentationDefinition
	DisplayName          string
	Generate             bool
	GenerateModel        bool
	GenerateIdValidation bool
	GenerateSchema       bool
	Label                string
	Mappings             MappingDefinition
	ReadMethod           MethodDefinition
	Resource             string
	ResourceIdName       string
	ResourceName         string
	SchemaModelName      string
	SchemaModels         map[string]TerraformSchemaModelDefinition
	Tests                TerraformResourceTestsDefinition
	UpdateMethod         *MethodDefinition
}

type MethodDefinition struct {
	Generate         bool
	MethodName       string
	TimeoutInMinutes int
}

type ResourceDocumentationDefinition struct {
	Category        string
	Description     string
	ExampleUsageHcl string
}

type MappingDefinitionType string

const (
	// DirectAssignmentTerraformFieldMappingDefinitionType specifies that this mapping defines a Direct Assignment
	// between a given Field within the Terraform Schema Model and a given Field in an SDK Model.
	DirectAssignmentTerraformFieldMappingDefinitionType MappingDefinitionType = "DirectAssignment"

	// ModelToModelTerraformFieldMappingDefinitionType specifies that this mapping defines a ModelToModel mapping
	// where the specified Schema Model should be mapped onto the given Field within a SDK Model - which relies
	// on a TerraformModelToModelMappingDefinition existing to define the mapping between the Schema Model and
	// the SDK Model.
	ModelToModelTerraformFieldMappingDefinitionType MappingDefinitionType = "ModelToModel"

	// ManualTerraformFieldMappingDefinitionType specifies that this mapping must be done manually.
	// Whilst this isn't currently used, it's piped through to allow an escape-hatch for atypical
	// scenarios requiring custom transformations.
	ManualTerraformFieldMappingDefinitionType MappingDefinitionType = "Manual"

	// TODO: support for other types of mappings e.g. BooleanEquals, BooleanInvert
)

type FieldMappingDirectAssignmentDefinition struct {
	SchemaModelName string
	SchemaFieldPath string
	SdkModelName    string
	SdkFieldPath    string
}

type FieldMappingModelToModelDefinition struct {
	SchemaModelName string
	SdkModelName    string
	SdkFieldName    string
}

type FieldManualMappingDefinition struct {
	MethodName string
}

type FieldMappingDefinition struct {
	Type             MappingDefinitionType
	DirectAssignment *FieldMappingDirectAssignmentDefinition
	ModelToModel     *FieldMappingModelToModelDefinition
	Manual           *FieldManualMappingDefinition
}

type ModelToModelMappingDefinition struct {
	SchemaModelName string
	SdkModelName    string
}

type ResourceIdMappingDefinition struct {
	SchemaFieldName    string
	SegmentName        string
	ParsedFromParentID bool
}

type MappingDefinition struct {
	Fields        []FieldMappingDefinition
	ModelToModels []ModelToModelMappingDefinition
	ResourceId    []ResourceIdMappingDefinition
}

type TerraformSchemaFieldType string

const (
	// BooleanTerraformSchemaObjectDefinitionType specifies that the Type represents a Boolean.
	BooleanTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Boolean"

	// DateTimeTerraformSchemaObjectDefinitionType specifies that the Type represents a DateTime.
	DateTimeTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "DateTime"

	// DictionaryTerraformSchemaObjectDefinitionType specifies that the Type represents a Dictionary
	// Dictionaries use a String value for a Key and the Value Type will be defined as a NestedItem
	// within the TerraformSchemaObjectDefinition.
	DictionaryTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Dictionary"

	// EdgeZoneTerraformSchemaObjectDefinitionType specifies that the Type represents an Edge Zone.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	EdgeZoneTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "EdgeZone"

	// LocationTerraformSchemaObjectDefinitionType specifies that the Type represents a Location.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	LocationTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Location"

	// FloatTerraformSchemaObjectDefinitionType specifies that the Type represents a Float.
	FloatTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Float"

	// IntegerTerraformSchemaObjectDefinitionType specifies that the Type represents an Integer.
	IntegerTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Integer"

	// ListTerraformSchemaObjectDefinitionType specifies that the Type represents a List where the Value
	// Type will be defined as a NestedItem within the TerraformSchemaObjectDefinition.
	ListTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "List"

	// ReferenceTerraformSchemaObjectDefinitionType specifies that the Type represents a Reference to
	// either a Constant or a Model.
	ReferenceTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Reference"

	// ResourceGroupTerraformSchemaObjectDefinitionType specifies that the Type represents a Resource Group Name.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	ResourceGroupTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "ResourceGroup"

	// SetTerraformSchemaObjectDefinitionType specifies that the Type is a Set where the Value
	// Type will be defined as a NestedItem within the TerraformSchemaObjectDefinition.
	SetTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Set"

	// SkuTerraformSchemaObjectDefinitionType specifies that the Type represents the name of a Sku.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SkuTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Sku"

	// StringTerraformSchemaObjectDefinitionType specifies that the Type represents a String.
	StringTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "String"

	// SystemAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a System Assigned (Managed) Identity.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SystemAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "SystemAssignedIdentity"

	// SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a System AND User Assigned Identity
	// supporting both a System Assigned (Managed) Identity, a User Assigned Identity - AND a combination of the two used together.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "SystemAndUserAssignedIdentity"

	// SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a System OR User Assigned Identity
	// supporting either a System Assigned (Managed) Identity or a User Assigned Identity - but not both.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "SystemOrUserAssignedIdentity"

	// TagsTerraformSchemaObjectDefinitionType specifies that the Type represents Tags
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	TagsTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Tags"

	// UserAssignedIdentityTerraformSchemaObjectDefinitionType specifies that the Type represents a User Assigned Identity.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	UserAssignedIdentityTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "UserAssignedIdentity"

	// ZoneTerraformSchemaObjectDefinitionType specifies that the Type represents a single (Availability) Zone.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	ZoneTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Zone"

	// ZonesTerraformSchemaObjectDefinitionType specifies that the Type represents multiple (Availability) Zones.
	// This is a CommonSchema type sourced from `hashicorp/go-azure-helpers`.
	ZonesTerraformSchemaObjectDefinitionType TerraformSchemaFieldType = "Zones"
)

type TerraformSchemaFieldObjectDefinition struct {
	NestedObject  *TerraformSchemaFieldObjectDefinition `json:"nestedObject,omitempty"`
	ReferenceName *string
	Type          TerraformSchemaFieldType
}

type TerraformSchemaDocumentationDefinition struct {
	Markdown string
}

type TerraformSchemaValidationPossibleValueType string

const (
	TerraformSchemaValidationPossibleValueTypeFloat  TerraformSchemaValidationPossibleValueType = "Float"
	TerraformSchemaValidationPossibleValueTypeInt    TerraformSchemaValidationPossibleValueType = "Int"
	TerraformSchemaValidationPossibleValueTypeString TerraformSchemaValidationPossibleValueType = "String"
)

type TerraformSchemaValidationPossibleValuesDefinition struct {
	Type   TerraformSchemaValidationPossibleValueType
	Values []interface{}
}

type TerraformSchemaValidationType string

const (
	// PossibleValuesTerraformSchemaValidationType specifies that there's a fixed set of possible values
	// allowed for this field.
	PossibleValuesTerraformSchemaValidationType TerraformSchemaValidationType = "PossibleValues"

	// TODO: we should implement `PossibleValuesFromConstant` and potentially others (NoEmptyValues/Ranges)
	// in the future
)

type TerraformSchemaValidationDefinition struct {
	Type           TerraformSchemaValidationType `json:"type"`
	PossibleValues *TerraformSchemaValidationPossibleValuesDefinition
}

type TerraformSchemaFieldDefinition struct {
	ObjectDefinition TerraformSchemaFieldObjectDefinition
	Computed         bool
	ForceNew         bool
	HclName          string
	Optional         bool
	Required         bool
	Documentation    TerraformSchemaDocumentationDefinition
	Validation       *TerraformSchemaValidationDefinition
}

type TerraformSchemaModelDefinition struct {
	Fields map[string]TerraformSchemaFieldDefinition
}

type TerraformResourceTestsDefinition struct {
	BasicConfiguration          string
	RequiresImportConfiguration string
	CompleteConfiguration       *string
	Generate                    bool
	OtherTests                  map[string][]string
	TemplateConfiguration       *string
}
