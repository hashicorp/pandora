package repositories

// NOTE: this is a copy of models from the package `dataapigeneratorjson` which is in the `importer-rest-api-specs` tool
// these have been duplicated to ease development and will be removed once `dataapigeneratorjson` has been split out

type Constant struct {
	Name   string  `json:"Name"`
	Type   string  `json:"Type"`
	Values []Value `json:"Values"`
}

type Value struct {
	Key         string  `json:"Key"`
	Value       string  `json:"Value"`
	Description *string `json:"Description,omitempty"`
}

type ResourceDefinition struct {
	DisplayName                  string `json:"DisplayName"`
	Id                           string `json:"Id"`
	Label                        string `json:"Label"`
	Category                     string `json:"Category"`
	Description                  string `json:"Description"`
	ExampleUsage                 string `json:"ExampleUsage"`
	GenerateIDValidationFunction bool   `json:"GenerateIDValidationFunction"`
	GenerateModel                bool   `json:"GenerateModel"`
	GenerateSchema               bool   `json:"GenerateSchema"`
	CreateMethod                 Method `json:"CreateMethod"`
	DeleteMethod                 Method `json:"DeleteMethod"`
	ReadMethod                   Method `json:"ReadMethod"`
	UpdateMethod                 Method `json:"UpdateMethod"`
}

type Method struct {
	Generate         bool   `json:"Generate"`
	Name             string `json:"Name"`
	TimeoutInMinutes int    `json:"TimeoutInMinutes"`
}

type ResourceMapping struct {
	ResourceIdMapping             *[]ResourceIdMapping            `json:"ResourceIdMapping,omitempty"`
	DirectAssignmentFieldMappings *[]DirectAssignmentFieldMapping `json:"DirectAssignmentFieldMappings,omitempty"`
	ModelToModelFieldMappings     *[]ModelToModelFieldMapping     `json:"ModelToModelFieldMappings,omitempty"`
}

type ResourceIdMapping struct {
	SchemaFieldName    string `json:"SchemaFieldName"`
	SegmentName        string `json:"SegmentName"`
	ParsedFromParentID bool   `json:"ParsedFromParentID"`
}

type DirectAssignmentFieldMapping struct {
	SchemaModelName string `json:"SchemaModelName"`
	SchemaFieldPath string `json:"SchemaFieldPath"`
	SdkModelName    string `json:"SdkModelName"`
	SdkFieldPath    string `json:"SdkFieldPath"`
}

type ModelToModelFieldMapping struct {
	SchemaModelName string `json:"SchemaModelName"`
	SdkModelName    string `json:"SdkModelName"`
	SdkFieldName    string `json:"SdkFieldName"`
}

type SchemaModel struct {
	Fields []SchemaField `json:"Fields"`
}

type SchemaField struct {
	HclName       string  `json:"HclName"`
	Type          string  `json:"Type"`
	Documentation *string `json:"Documentation,omitempty"`
	Required      *bool   `json:"Required,omitempty"`
	Optional      *bool   `json:"Optional,omitempty"`
	Computed      *bool   `json:"Computed,omitempty"`
	ForceNew      *bool   `json:"ForceNew,omitempty"`
	Name          string  `json:"Name"`
	// todo import this
	// Constants        *resourcemanager.ConstantDetails `json:"Constants,omitempty"`
	ObjectDefinition *SchemaFieldObjectDefinition `json:"ObjectDefinition,omitempty"`
}

type SchemaFieldObjectDefinition struct {
	Type          TerraformSchemaFieldType     `json:"Type"`
	ReferenceName *string                      `json:"ReferenceName,omitempty"`
	NestedObject  *SchemaFieldObjectDefinition `json:"NestedObject,omitempty"`
}

type TerraformResourceTestConfig struct {
	Basic          string  `json:"Basic"`
	RequiresImport string  `json:"RequiresImport"`
	CompleteConfig *string `json:"CompleteConfig,omitempty"`
	TemplateConfig *string `json:"TemplateConfig,omitempty"`
}
