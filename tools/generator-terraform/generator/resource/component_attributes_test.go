package resource

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentAttributes(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"OptionalNestedItem": {
						HclName: "optional_nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: pointer.To("NestedSchema"),
						},
						Optional: true,
					},
					"RequiredInteger": {
						HclName: "required_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Required: true,
					},
					"OptionalInteger": {
						HclName: "optional_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Optional: true,
					},
					"ComputedInteger": {
						HclName: "computed_integer",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Computed: true,
					},
					"RequiredString": {
						HclName: "required_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
					},
					"OptionalString": {
						HclName: "optional_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"ComputedString": {
						HclName: "computed_string",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"NestedItem": {
						HclName: "nested_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"ComputedItem": {
						HclName: "computed_item",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
					},
				},
			},
		},
	}
	actual, err := attributesCodeFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Attributes() map[string]*pluginsdk.Schema {
	return map[string]*pluginsdk.Schema{
		"computed_integer": {
			Computed: true,
			Type: pluginsdk.TypeInt,
		},
		"computed_string": {
			Computed: true,
			Type: pluginsdk.TypeString,
		},
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
