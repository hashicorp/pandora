package testattributes

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTestAttributes_CodeForBasicFields(t *testing.T) {
	input := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"required_bool_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Boolean",
				},
				Required: true,
			},
			"required_float_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Float",
				},
				Required: true,
			},
			"required_int_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "Integer",
				},
				Required: true,
			},
			"required_string_attribute": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: "String",
				},
				Required: true,
			},
		},
	}
	expected := `
	required_bool_attribute   = false
	required_float_attribute  = 10.1
	required_int_attribute    = 15
	required_string_attribute = "foo"
`

	actual, err := codeForTestConfig(input)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, actual)
}
