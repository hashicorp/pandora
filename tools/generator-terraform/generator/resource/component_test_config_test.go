package resource

import (
	"fmt"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestGenerateBasicTest_basic(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		ResourceLabel:    "example",
		ProviderPrefix:   "azurerm",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:   true,
				MethodName: "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
			SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TestResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"RequiredBoolAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "Boolean",
							},
							HclName:  "required_bool_attribute",
							Required: true,
						},
						"RequiredFloatAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "Float",
							},
							HclName:  "required_float_attribute",
							Required: true,
						},
						"RequiredIntAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "Integer",
							},
							HclName:  "required_int_attribute",
							Required: true,
						},
						"RequiredStringAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "String",
							},
							HclName:  "required_string_attribute",
							Required: true,
						},
					},
				},
			},
			SchemaModelName: "TestResource",
		},
	}
	actual, err := generateBasicTestConfig(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := fmt.Sprintf(`
func (ExampleResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf(%[1]s
resource "azurerm_example" "test" {
	required_bool_attribute   = false
	required_float_attribute  = 10.1
	required_int_attribute    = 15
	required_string_attribute = "foo"
}
%[1]s)}
`, "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestGenerateImportTest_basic(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		ResourceLabel:    "example",
		ProviderPrefix:   "azurerm",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:   true,
				MethodName: "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
			SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TestResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"RequiredBoolAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "Boolean",
							},
							HclName:  "required_bool_attribute",
							Required: true,
						},
						"RequiredFloatAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "Float",
							},
							HclName:  "required_float_attribute",
							Required: true,
						},
						"RequiredIntAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "Integer",
							},
							HclName:  "required_int_attribute",
							Required: true,
						},
						"RequiredStringAttribute": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: "String",
							},
							HclName:  "required_string_attribute",
							Required: true,
						},
					},
				},
			},
			SchemaModelName: "TestResource",
		},
	}
	actual, err := generateImportTestConfig(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := fmt.Sprintf(`
func (ExampleResource) requiresImport(data acceptance.TestData) string {
	return fmt.Sprintf(%[1]s
resource "azurerm_example" "import" {
	required_bool_attribute   = azurerm_example.test.required_bool_attribute
	required_float_attribute  = azurerm_example.test.required_float_attribute
	required_int_attribute    = azurerm_example.test.required_int_attribute
	required_string_attribute = azurerm_example.test.required_string_attribute
}
%[1]s)}
`, "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
