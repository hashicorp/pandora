package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForArgumentsReference(input models.ResourceInput) (*string, error) {

	topLevelArgs, err := getArguments(input.SchemaModels[input.SchemaModelName], input.Details.DisplayName)
	if err != nil {
		return nil, err
	}

	output := fmt.Sprintf(`
## Arguments Reference

The following arguments are supported:

%s

`, *topLevelArgs)

	return &output, nil
}

func getArguments(model resourcemanager.TerraformSchemaModelDefinition, resourceName string) (*string, error) {

	requiredLines := make([]string, 0)
	optionalLines := make([]string, 0)

	sortedFieldNames := sortFieldNamesAlphabetically(model)

	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]

		// skip attributes
		if field.Computed && !field.Optional && !field.Required {
			continue
		}

		components := make([]string, 0)
		components = append(components, fmt.Sprintf("* `%s` -", field.HclName))

		if field.Required {
			components = append(components, "(Required)")
		} else if field.Optional {
			components = append(components, "(Optional)")
		}

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

		// TODO update to include ranges
		if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeBoolean {
			components = append(components, "Possible values are `true` and `false`.")
		} else if field.Validation != nil {
			if field.Validation.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues {
				if values := field.Validation.PossibleValues.Values; values != nil {
					possibleValues := wordifyPossibleValues(values)
					components = append(components, possibleValues)
				}
			}
		}

		// TODO set default if applicable?

		if field.ForceNew {
			components = append(components, fmt.Sprintf("Changing this forces a new %s to be created.", resourceName))
		}

		line := removeExtraSpaces(strings.Join(components, " "))

		// sort required and optional
		if field.Required {
			requiredLines = append(requiredLines, line)
		} else {
			optionalLines = append(optionalLines, line)
		}
	}
	out := strings.Join(append(requiredLines, optionalLines...), "\n\n")
	return &out, nil
}
