package generator

import (
	"fmt"
	"strings"
)

type Data struct {
	// ClientName is the full path to access this SDK Client
	// for example `Example.ExampleClients` or `Resources.GroupsClient`
	ClientName string

	// ResourceIDTypeName is the name of the Type used for the Resource ID
	ResourceIDTypeName *string

	// IsResource specifies whether this is a Terraform Data Source or a Resource
	IsResource bool

	// ResourceName is the name of this resource e.g. `Foo` which gets transformed into `azurerm_foo`
	ResourceName string

	// ResourceType is the Terraform Resource Type e.g. `azurerm_foo`
	ResourceType string

	// PackageName is the name of the Go Package where this resource should be generated
	PackageName string

	// PackageWorkingDirectory is a fully qualified path for the Working Directory for this Package
	PackageWorkingDirectory string

	// ProviderPrefix is the prefix used for this provider (e.g. `azurerm`)
	ProviderPrefix string

	// DataSourceReadOperation describes the Read operation for a Data Source
	DataSourceReadOperation *OperationDetails

	// DataSourceTestCases describes the test cases for a Data Source
	DataSourceTestCases *TestCasesDefinition

	// ResourceCreateOperation describes the Create operation for a resource
	ResourceCreateOperation *OperationDetails

	// ResourceDeleteOperation describes the Delete operation for a Resource
	ResourceDeleteOperation *OperationDetails

	// ResourceReadOperation describes the Read operation for a resource
	ResourceReadOperation *OperationDetails

	// ResourceUpdateOperation describes the Read operation for a resource
	ResourceUpdateOperation *OperationDetails

	// ResourceTestCases describes the test cases for a Resource
	ResourceTestCases *TestCasesDefinition

	// SchemaFieldsToResourceIDMappings is a list of schema fields within the Model which should be used
	// to construct the Resource ID Mapping
	SchemaFieldsToResourceIDMappings *[]string

	// TopLevelSchema defines the top level fields
	TopLevelSchema *ModelDefinition

	// Objects defines the Constants and Models used by the Top Level Schema
	Objects *Objects

	// fileNamePrefix is the computed filename prefix for this resource
	// in the format `example_resource` or `example_data_source`
	fileNamePrefix string
}

type TestCasesDefinition struct {
	Configs map[string]TestConfigDefinition
	Tests   map[string]TestCaseDefinition
}

type TestCaseDefinition struct {
	Stages []TestCaseDefinitionStage
}

type TestCaseDefinitionStage struct {
	ConfigName     *string
	Import         bool
	RequiresImport bool
	// TODO: assertions ..
}

type TestConfigDefinition struct {
	Config string
	// TODO: this could also house 'variables' I guess?
}

func (d *Data) process() error {
	resourceType := "resource"
	if !d.IsResource {
		resourceType = "data"
	}
	d.fileNamePrefix = fmt.Sprintf("%s_%s", strings.ToLower(d.ResourceName), resourceType)

	return nil
}

type Objects struct {
	Constants map[string]ConstantDefinition
	Models    map[string]ModelDefinition
}

type ConstantDefinition struct {
	FieldType     ConstantFieldType
	ModelAsString bool
	Values        map[string]string
}

type ConstantFieldType string

const (
	IntegerConstant ConstantFieldType = "int"
	FloatConstant   ConstantFieldType = "float"
	StringConstant  ConstantFieldType = "string"
	UnknownConstant ConstantFieldType = "unknown"
)

type ModelDefinition struct {
	Description string
	Fields      map[string]FieldDefinition
}

type FieldDefinition struct {
	Computed          bool
	ConstantReference *string
	Default           *interface{}
	Deprecated        bool
	Description       string
	ForceNew          bool
	HclLabel          string
	MaxItems          *int
	ModelReference    *string
	MinItems          *int
	Optional          bool
	Required          bool
	Sensitive         bool
	Type              FieldTypeDefinition
	// TODO: validation
}

type FieldTypeDefinition string

const (
	FieldTypeDefinitionBoolean       FieldTypeDefinition = "Boolean"
	FieldTypeDefinitionConstant      FieldTypeDefinition = "Constant"
	FieldTypeDefinitionFloat         FieldTypeDefinition = "Float"
	FieldTypeDefinitionInteger       FieldTypeDefinition = "Integer"
	FieldTypeDefinitionJson          FieldTypeDefinition = "Json"
	FieldTypeDefinitionMap           FieldTypeDefinition = "Map"
	FieldTypeDefinitionList          FieldTypeDefinition = "List"
	FieldTypeDefinitionLocation      FieldTypeDefinition = "Location"
	FieldTypeDefinitionResourceGroup FieldTypeDefinition = "ResourceGroup"
	FieldTypeDefinitionSet           FieldTypeDefinition = "Set"
	FieldTypeDefinitionString        FieldTypeDefinition = "String"
	FieldTypeDefinitionTags          FieldTypeDefinition = "Tags"
	FieldTypeDefinitionUnknown       FieldTypeDefinition = "Unknown"
)
