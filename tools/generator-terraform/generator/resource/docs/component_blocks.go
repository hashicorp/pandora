package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForBlocksReference(input models.ResourceInput) (*string, error) {

	blocks := make(map[string]string)

	for _, field := range input.SchemaModels[input.SchemaModelName].Fields {
		if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			mergeBlocksMapWithNestedBlocks(blocks, populateBlockAndNestedBlocks(field.HclName, input, input.SchemaModels[*field.ObjectDefinition.ReferenceName]))
		}
	}

	output := ""
	if len(blocks) > 0 {
		output = "## Blocks Reference\n"

		sortedBlockNames := sortStringStringMapKeys(blocks)
		for _, block := range sortedBlockNames {
			output = fmt.Sprintf("%s%s", output, blocks[block])
			output = fmt.Sprintf("%s%s", output, "\n\n---\n")
		}
	}

	return &output, nil
}

func getFieldsAndNestedBlocks(blockHclName string, input models.ResourceInput, model resourcemanager.TerraformSchemaModelDefinition) (string, string, map[string]string) {

	requiredLines := make([]string, 0)
	optionalLines := make([]string, 0)
	attributeLines := make([]string, 0)
	blocks := make(map[string]string)

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

			components = append(components, fmt.Sprintf("`%s` block as defined", field.HclName))

			// blocks are organised alphabetically, so checking order of nested block compared to parent block here
			if strings.Compare(field.HclName, blockHclName) == 1 {
				components = append(components, "below.")
			} else {
				components = append(components, "above.")
			}
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
				if field.Validation.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues {
					if field.Validation.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues {
						if values := field.Validation.PossibleValues.Values; values != nil {
							possibleValues := wordifyPossibleValues(values)
							components = append(components, possibleValues)
						}
					}
				}
			}

			// TODO set default if applicable?

			if field.ForceNew {
				components = append(components, fmt.Sprintf("Changing this forces a new %s to be created.", input.Details.DisplayName))
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
			mergeBlocksMapWithNestedBlocks(blocks, populateBlockAndNestedBlocks(field.HclName, input, input.SchemaModels[*field.ObjectDefinition.ReferenceName]))
		}
	}
	return strings.Join(append(requiredLines, optionalLines...), "\n\n"), strings.Join(attributeLines, "\n\n"), blocks
}

func populateBlockAndNestedBlocks(blockHclName string, input models.ResourceInput, model resourcemanager.TerraformSchemaModelDefinition) map[string]string {

	blocks := make(map[string]string)
	blockArgs, blockAttributes, nestedBlocks := getFieldsAndNestedBlocks(blockHclName, input, model)

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

	blocks[blockHclName] = strings.Join(components, "\n\n")

	return mergeBlocksMapWithNestedBlocks(blocks, nestedBlocks)
}

func mergeBlocksMapWithNestedBlocks(blocksMap map[string]string, nestedBlocksMap map[string]string) map[string]string {
	for k, v := range nestedBlocksMap {
		blocksMap[k] = v
	}
	return blocksMap
}
