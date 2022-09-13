package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForBlocksReference(input models.ResourceInput) (*string, error) {

	blocks := make([]string, 0)
	topLevelModel := input.SchemaModels[input.SchemaModelName]
	fieldNames := sortFieldNamesAlphabetically(input.SchemaModels[input.SchemaModelName])

	for _, fieldName := range fieldNames {
		field := topLevelModel.Fields[fieldName]
		if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			blocks = append(blocks, populateBlockAndNestedBlocks(field.HclName, input, input.SchemaModels[*field.ObjectDefinition.ReferenceName])...)
		}
	}

	output := ""

	if len(blocks) > 0 {
		output = fmt.Sprintf(`

## Blocks Reference
%s

---`, strings.Join(blocks, "\n\n---\n"))

	}

	return &output, nil
}

func getFieldsAndNestedBlocks(input models.ResourceInput, model resourcemanager.TerraformSchemaModelDefinition) (string, string, []string) {

	requiredLines := make([]string, 0)
	optionalLines := make([]string, 0)
	attributeLines := make([]string, 0)
	blocks := make([]string, 0)

	sortedFieldNames := sortFieldNamesAlphabetically(model)

	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]
		components := make([]string, 0)
		components = append(components, fmt.Sprintf("* `%s` -", field.HclName))

		if field.Required {
			components = append(components, "(Required)")
		} else if field.Optional {
			components = append(components, "(Optional)")
		}

		// identify block
		isReference := field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference
		if isReference {
			if beginsWithVowel(field.HclName) {
				components = append(components, "An")
			} else {
				components = append(components, "A")
			}
			components = append(components, fmt.Sprintf("`%s` block as defined below.", field.HclName))
		}

		// TODO markdown always blank - may require changes here based on markdown format. Assuming this is like a field description for now
		components = append(components, field.Documentation.Markdown)

		isAttribute := false
		if field.Computed && !field.Optional && !field.Required {
			isAttribute = true
		}

		if !isAttribute {
			// TODO update to include ranges
			if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeBoolean {
				components = append(components, "Possible values are `true` and `false`.")
			} else if field.Validation != nil {
				if field.Validation.Type == resourcemanager.TerraformSchemaValidationTypeFixedValues {
					if values := field.Validation.PossibleValues; values != nil {
						possibleValues := fmt.Sprintf("Possible values are `%s.`", strings.Join(*values, "`, `"))
						components = append(components, possibleValues)
					}
				}
			}

			// TODO set default if applicable?

			if field.ForceNew {
				components = append(components, "Changing this forces a new resource to be created.")
			}
		}

		line := strings.Join(components, " ")

		if field.Required {
			requiredLines = append(requiredLines, line)
		} else if field.Optional {
			optionalLines = append(optionalLines, line)
		} else if isAttribute {
			attributeLines = append(attributeLines, line)
		}

		if isReference {
			blocks = append(blocks, populateBlockAndNestedBlocks(field.HclName, input, input.SchemaModels[*field.ObjectDefinition.ReferenceName])...)
		}
	}
	return strings.Join(append(requiredLines, optionalLines...), "\n\n"), strings.Join(attributeLines, "\n\n"), blocks
}

func populateBlockAndNestedBlocks(blockHclName string, input models.ResourceInput, model resourcemanager.TerraformSchemaModelDefinition) []string {

	blocks := make([]string, 0)
	blockArgs, blockAttributes, nestedBlocks := getFieldsAndNestedBlocks(input, model)

	components := make([]string, 0)
	components = append(components, fmt.Sprintf("\n### `%s` Block", blockHclName))

	if blockArgs != "" {
		components = append(components, fmt.Sprintf("The `%s` block supports the following arguments:", blockHclName))
		components = append(components, fmt.Sprintf("%s", blockArgs))
	}

	if blockAttributes != "" {
		components = append(components, fmt.Sprintf("The `%s` block exports the following arguments:", blockHclName))
		components = append(components, fmt.Sprintf("%s", blockAttributes))
	}

	blocks = append(blocks, strings.Join(components, "\n\n"))
	blocks = append(blocks, nestedBlocks...)

	return blocks
}
