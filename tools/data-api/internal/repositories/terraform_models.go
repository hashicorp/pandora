package repositories

const (
	StringTerraformSchemaFieldType TerraformSchemaFieldType = "String"
)

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

type TerraformSchemaFieldObjectDefinition struct {
	NestedObject  *TerraformSchemaFieldObjectDefinition `json:"nestedObject,omitempty"`
	ReferenceName *string
	Type          TerraformSchemaFieldType
}

type TerraformSchemaDocumentationDefinition struct {
	Markdown string
}

type TerraformSchemaValidationPossibleValueType string

type TerraformSchemaValidationPossibleValuesDefinition struct {
	Type   TerraformSchemaValidationPossibleValueType
	Values []interface{}
}

type TerraformSchemaValidationType string

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
