package docs

import (
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForArgumentsReference(input models.ResourceInput) (*string, error) {
	// TODO: first we need to output the top level model (e.g. the model for the resource) which
	// can be found via `input.SchemaModelName`

	// NOTE: when we output both we'll want to ensure the ordering is Required -> Optional -> Computed

	arguments := make([]string, 0)
	//blockArguments := make([]string, 0)

	for modelName, model := range input.SchemaModels {
		// already output above, so we can skip it
		if modelName == input.SchemaModelName {
			continue
		}

		for fieldName := range model.Fields {
			log.Printf("Model %q / Field %q", modelName, fieldName)
		}

		// if this is not the top level schema, generate block doc
		/*		if !strings.HasSuffix(modelName, "ResourceSchema") {
				blockHcl := convertToSnakeCase(strings.TrimSuffix(modelName, "Schema"))

				// TODO get compute/required/optional
				block := fmt.Sprintf("* `%s` - A `%s` block as defined below.", blockHcl, blockHcl)
				arguments = append(arguments, block)
				blockArguments = append(blockArguments, getBlock(model.Fields, blockHcl))
				continue
			}*/

		arguments = append(arguments, getFieldLines(model.Fields))

	}

	output := fmt.Sprintf(`
## Argument Reference

The following arguments are supported:

%s

---
`, strings.Join(arguments, "\n"))

	return &output, nil
}

func getFieldLines(fields map[string]resourcemanager.TerraformSchemaFieldDefinition) string {
	lines := make([]string, 0)
	for _, field := range fields {

		components := make([]string, 0)

		// skip attributes
		if field.Computed && !field.Optional && !field.Required {
			continue
		}

		components = append(components, fmt.Sprintf("* `%s` -", field.HclName))

		if field.Required {
			components = append(components, "(Required)")
		} else if field.Optional {
			components = append(components, "(Optional)")
		}

		// TODO markdown always blank - check this
		components = append(components, field.Documentation.Markdown)

		// TODO fix this. include ranges? how??
		// TODO possible values & type always blank - check
		possibleValues := ""
		if field.Validation != nil {
			if field.Validation.Type == resourcemanager.TerraformSchemaValidationTypeFixedValues {
				if values := field.Validation.PossibleValues; values != nil {
					possibleValues = fmt.Sprintf("Possible values are %s.", strings.Join(*values, ","))
					components = append(components, possibleValues)
				}
			}
		}

		if field.ForceNew {
			components = append(components, "Changing this forces a new resource to be created.")
		}

		line := strings.Join(components, " ")

		lines = append(lines, line)
	}
	return strings.Join(lines, "\n\n")
}

func getBlock(fields map[string]resourcemanager.TerraformSchemaFieldDefinition, blockHclName string) string {

	lines := getFieldLines(fields)

	// TODO get computed/required/optional at block level?
	block := "\n---\n"
	block = fmt.Sprintf("%s### Block `%s` \n", block, blockHclName)
	block = fmt.Sprintf("%s The `%s` block supports the following arguments:", block, blockHclName)
	block = fmt.Sprintf(`
%s
%s
		`, block, lines)

	return block
}
