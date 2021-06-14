package main

import (
	"fmt"
	"log"
	"os"
	"path"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator"
)

func main() {
	dataEndpoint := "http://localhost:5000"
	debug := true
	homeDir, _ := os.UserHomeDir()
	if err := run(dataEndpoint, homeDir, debug); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(endpoint, homeDir string, debug bool) error {
	data := map[string]generator.Data{
		"EventHub Namespace": {
			ClientName:              "EventHubs.NamespacesClient",
			IsResource:              true,
			ResourceName:            "Namespace",
			PackageName:             "eventhubs",
			ProviderPrefix:          "azurerm",
			PackageWorkingDirectory: path.Join(homeDir, "Desktop/pandora-terraform/eventhubs"),
			ResourceType:            "azurerm_eventhub_namespace",
			ResourceIDTypeName:      strPtr("Namespace"),

			ResourceDeleteOperation: &generator.OperationDetails{
				CustomTimeoutInMinutes: intPtr(60),
				Generate:               true,
				SDKMethodIsLongRunning: false,
				SDKMethodName:          "Delete",
			},
			ResourceReadOperation: &generator.OperationDetails{
				Generate:               true,
				SDKMethodIsLongRunning: false,
				SDKMethodName:          "Get",
				SDKModelName:           strPtr("SomeReadModel"),
			},
		},
		"Resource Group - Data Source": {
			ClientName:              "Resources.GroupsClient",
			IsResource:              false,
			PackageName:             "resources",
			ProviderPrefix:          "azurerm",
			PackageWorkingDirectory: path.Join(homeDir, "Desktop/pandora-terraform/resources"),
			ResourceIDTypeName:      strPtr("ResourceGroup"),
			ResourceName:            "ResourceGroup",
			ResourceType:            "azurerm_resource_group",

			DataSourceReadOperation: &generator.OperationDetails{
				Generate:      true,
				SDKMethodName: "DataSourceGetPlz",
				SDKModelName:  strPtr("ModelForDataSource"),
			},
			DataSourceTestCases: &generator.TestCasesDefinition{
				Tests: map[string]generator.TestCaseDefinition{
					"Basic": {
						Stages: []generator.TestCaseDefinitionStage{
							{
								ConfigName:     strPtr("basic"),
								Import:         false,
								RequiresImport: false,
							},
						},
					},
				},
				Configs: map[string]generator.TestConfigDefinition{
					"basic": {
						Config: `
resource "azurerm_resource_group" "test" {
  name     = "tom-dev"
  location = "west europe"
}
`,
					},
				},
			},
		},
		"Resource Group - Resource": {
			ClientName:              "Resources.GroupsClient",
			IsResource:              true,
			PackageName:             "resources",
			ProviderPrefix:          "azurerm",
			PackageWorkingDirectory: path.Join(homeDir, "Desktop/pandora-terraform/resources"),
			ResourceIDTypeName:      strPtr("ResourceGroup"),
			ResourceName:            "ResourceGroup",
			ResourceType:            "azurerm_resource_group",
			SchemaFieldsToResourceIDMappings: &[]string{
				"Name",
			},

			TopLevelSchema: &generator.ModelDefinition{
				Fields: map[string]generator.FieldDefinition{
					"Name": {
						Type:     generator.FieldTypeDefinitionResourceGroup,
						Required: true,
						ForceNew: true,
						HclLabel: "name",
					},
					"Location": {
						Type:     generator.FieldTypeDefinitionLocation,
						Required: true,
						ForceNew: true,
						HclLabel: "location",
					},
					"Tags": {
						Type:     generator.FieldTypeDefinitionTags,
						Computed: true,
						HclLabel: "tags",
					},
					"NestedObject": {
						Type:           generator.FieldTypeDefinitionList,
						HclLabel:       "nested_object",
						MinItems:       intPtr(1),
						MaxItems:       intPtr(1),
						ModelReference: strPtr("Nested"),
					},
				},
			},
			Objects: &generator.Objects{
				Constants: map[string]generator.ConstantDefinition{
					"Names": {
						FieldType: generator.StringConstant,
						Values: map[string]string{
							"Bob":   "bob",
							"Chloe": "chloe",
						},
					},
				},
				Models: map[string]generator.ModelDefinition{
					"Nested": {
						Fields: map[string]generator.FieldDefinition{
							"Name": {
								Type:     generator.FieldTypeDefinitionString,
								Required: true,
								ForceNew: true,
								HclLabel: "name",
							},
							"ConstantValue": {
								Type:              generator.FieldTypeDefinitionConstant,
								Required:          true,
								ForceNew:          true,
								HclLabel:          "constant_value",
								ConstantReference: strPtr("Names"),
							},
						},
					},
				},
			},

			ResourceCreateOperation: &generator.OperationDetails{
				Generate:               true,
				SDKMethodIsLongRunning: true,
				SDKMethodName:          "Create",
				SDKModelName:           strPtr("SomeCreateModel"),
			},
			ResourceDeleteOperation: &generator.OperationDetails{
				Generate:               true,
				SDKMethodIsLongRunning: true,
				SDKMethodName:          "Delete",
			},
			ResourceReadOperation: &generator.OperationDetails{
				Generate:      true,
				SDKMethodName: "Read",
				SDKModelName:  strPtr("MyCustomReadObj"),
			},
			ResourceUpdateOperation: &generator.OperationDetails{
				Generate:      true,
				SDKMethodName: "UpdateAllTheThings",
				SDKModelName:  strPtr("MyCustomUpdateObj"),
			},
			ResourceTestCases: &generator.TestCasesDefinition{
				Tests: map[string]generator.TestCaseDefinition{
					"Basic": {
						Stages: []generator.TestCaseDefinitionStage{
							{
								ConfigName: strPtr("basic"),
							},
							{
								Import: true,
							},
						},
					},
					"Complete": {
						Stages: []generator.TestCaseDefinitionStage{
							{
								ConfigName: strPtr("basic"),
							},
							{
								Import: true,
							},
							{
								ConfigName: strPtr("complete"),
							},
							{
								Import: true,
							},
						},
					},
					"RequiresImport": {
						Stages: []generator.TestCaseDefinitionStage{
							{
								ConfigName: strPtr("basic"),
							},
							{
								ConfigName:     strPtr("requiresImport"),
								RequiresImport: true,
							},
						},
					},
				},
				Configs: map[string]generator.TestConfigDefinition{
					"basic": {
						Config: `
resource "azurerm_resource_group" "test" {
  name     = "tom-dev"
  location = "west europe"
}
`,
					},
					"complete": {
						Config: `
resource "azurerm_resource_group" "test" {
  name     = "tom-dev"
  location = "west europe"
  tags = {
    "generated-by" = "Pandora"
  }
}
`,
					},
					"requiresImport": {
						Config: `
resource "azurerm_resource_group" "test" {
  name     = "tom-dev"
  location = "west europe"
}

resource "azurerm_resource_group" "import" {
  name     = azurerm_resource_group.test.name
  location = azurerm_resource_group.test.location
}
`,
					},
				},
			},
		},
	}

	for name, val := range data {
		log.Printf("[DEBUG] Generating %q..", name)
		gen := generator.NewGenerator(val, debug)
		if err := gen.Generate(); err != nil {
			return fmt.Errorf("generating: %+v", err)
		}
	}

	//client := resourcemanager.NewClient(endpoint)
	//services, err := services.GetResourceManagerServices(client)
	//if err != nil {
	//	return fmt.Errorf("retrieving services: %+v", err)
	//}
	//
	//for _, val := range services.Services {
	//	if !val.Details.Generate {
	//		continue
	//	}
	//
	//
	//}

	return nil
}

func intPtr(in int) *int {
	return &in
}

func strPtr(in string) *string {
	return &in
}
