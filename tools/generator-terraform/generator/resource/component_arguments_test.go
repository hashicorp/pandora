package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestComponentArguments(t *testing.T) {
	actual := argumentsCodeFunctionForResource(models.ResourceInput{
		ResourceTypeName: "Example",
		SchemaModelName:  "TopLevelModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"optional_nested_item": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type:          resourcemanager.TerraformSchemaFieldTypeReference,
							ReferenceName: stringPointer("NestedSchema"),
						},
						Optional: true,
					},
					"required_integer": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Required: true,
					},
					"optional_integer": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Optional: true,
					},
					"computed_integer": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeInteger,
						},
						Computed: true,
					},
					"required_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
					},
					"optional_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"computed_string": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
					},
				},
			},
			"NestedSchema": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"nested_item": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Optional: true,
					},
					"computed_item": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Computed: true,
					},
				},
			},
		},
	})
	expected := `
func (r ExampleResource) Arguments() map[string]*pluginsdk.Schema {
	return map[string]*pluginsdk.Schema{
		"required_integer": {
			Required: true,
			Type: pluginsdk.TypeInt,
		},
		"required_string": {
			Required: true,
			Type: pluginsdk.TypeString,
		},
		"optional_integer": {
			Optional: true,
			Type: pluginsdk.TypeInt,
		},
		"optional_nested_item": {
			Elem: &pluginsdk.Resource{
				Schema: map[string]*pluginsdk.Schema{
					"nested_item": {
						Optional: true,
						Type: pluginsdk.TypeString,
					},
					"computed_item": {
						Computed: true,
						Type: pluginsdk.TypeString,
					},
				},
			},
			MaxItems: 1,
			Optional: true,
			Type: pluginsdk.TypeList,
		},
		"optional_string": {
			Optional: true,
			Type: pluginsdk.TypeString,
		},
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
