package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForAttributesReference(input models.ResourceInput) (*string, error) {

	components := make([]string, 0)
	components = append(components, "## Attributes Reference")
	components = append(components, "The following attributes are exported:")
	components = append(components, fmt.Sprintf("* `id` - The ID of the %s.", input.Details.DisplayName))

	topLevelAttributes, err := getAttributes(input.SchemaModels[input.SchemaModelName])
	if err != nil {
		return nil, err
	}
	if topLevelAttributes != nil && *topLevelAttributes != "" {
		components = append(components, *topLevelAttributes)
	}
	components = append(components, "---")

	output := strings.Join(components, "\n\n")

	return &output, nil
}

func getAttributes(model resourcemanager.TerraformSchemaModelDefinition) (*string, error) {

	lines := make([]string, 0)
	sortedFieldNames := sortFieldNamesAlphabetically(model)

	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]
		if field.Computed && !field.Optional && !field.Required {

			components := make([]string, 0)
			components = append(components, fmt.Sprintf("* `%s` -", field.HclName))

			// identify block
			if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
				fieldBeginsWithVowel, err := beginsWithVowel(field.HclName)
				if err != nil {
					return nil, err
				}
				if fieldBeginsWithVowel {
					components = append(components, "An")
				} else {
					components = append(components, "A")
				}
				components = append(components, fmt.Sprintf("`%s` block as defined below.", field.HclName))
			}
			components = append(components, field.Documentation.Markdown)

			line := removeExtraSpaces(strings.Join(components, " "))
			lines = append(lines, line)
		}
	}
	out := strings.Join(append(lines), "\n\n")
	return &out, nil
}
