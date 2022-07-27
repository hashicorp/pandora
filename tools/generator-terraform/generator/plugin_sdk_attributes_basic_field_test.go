package generator

import (
	"fmt"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO:  w/Validation

func TestPluginSdkAttributes_CodeForBasicFields(t *testing.T) {
	basicFieldTypes := map[resourcemanager.TerraformSchemaFieldType]string{
		resourcemanager.TerraformSchemaFieldTypeBoolean: "pluginsdk.TypeBool",
		resourcemanager.TerraformSchemaFieldTypeFloat:   "pluginsdk.TypeFloat",
		resourcemanager.TerraformSchemaFieldTypeInteger: "pluginsdk.TypeInt",
		resourcemanager.TerraformSchemaFieldTypeString:  "pluginsdk.TypeString",
	}
	for fieldType, pluginSdkType := range basicFieldTypes {
		t.Run(fmt.Sprintf("Field Type %q", string(fieldType)), func(t *testing.T) {
			testData := []struct {
				input    resourcemanager.TerraformSchemaFieldDefinition
				expected string
			}{
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: false,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
"my_field": {
	Required: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: true,
						Optional: false,
						Required: true,
					},
					expected: fmt.Sprintf(`
"my_field": {
	ForceNew: true,
	Required: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: false,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
"my_field": {
	Optional: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: fieldType,
						},
						Computed: false,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
"my_field": {
	ForceNew: true,
	Optional: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: fieldType,
						},
						Computed: true,
						ForceNew: true,
						Optional: true,
						Required: false,
					},
					expected: fmt.Sprintf(`
"my_field": {
	Computed: true,
	ForceNew: true,
	Optional: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
				{
					input: resourcemanager.TerraformSchemaFieldDefinition{
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: fieldType,
						},
						Computed: true,
						ForceNew: false,
						Optional: false,
						Required: false,
					},
					expected: fmt.Sprintf(`
"my_field": {
	Computed: true,
	Type: %[1]s,
}
`, pluginSdkType),
				},
			}
			for i, testCase := range testData {
				helper := pluginSdkAttributesHelpers{}
				actual, err := helper.codeForPluginSdkAttribute("my_field", testCase.input)
				if err != nil {
					if testCase.expected == "" {
						continue
					}

					t.Fatalf("unexpected error for index %d", i)
				}
				if testCase.expected == "" {
					t.Fatalf("expected an error but didn't get one for index %d", i)
				}
				assertTemplatedCodeMatches(t, testCase.expected, *actual)
			}
		})
	}
}
