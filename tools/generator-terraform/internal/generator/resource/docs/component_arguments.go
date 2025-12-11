// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForArgumentsReference(input generatorModels.ResourceInput) (*string, error) {
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

func getArguments(model models.TerraformSchemaModel, resourceName string) (*string, error) {
	requiredLines := make([]string, 0)
	optionalLines := make([]string, 0)

	sortedFieldNames := sortFieldNamesAlphabetically(model)

	// first process the Required Arguments
	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]

		// we only want Required Arguments
		if !field.Required || field.Optional || field.Computed {
			continue
		}

		nestedWithin := "" // top-level so not nested
		docs, err := documentationLineForArgument(field, nestedWithin, resourceName)
		if err != nil {
			return nil, fmt.Errorf("building documentation line for required argument/field %q: %+v", fieldName, err)
		}
		requiredLines = append(requiredLines, *docs)
	}

	// then process the Optional Arguments
	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]

		// we only want Optional Arguments (which includes Optional + Computed fields)
		if !field.Optional || field.Required {
			continue
		}

		nestedWithin := "" // top-level so not nested
		docs, err := documentationLineForArgument(field, nestedWithin, resourceName)
		if err != nil {
			return nil, fmt.Errorf("building documentation line for optional argument/field %q: %+v", fieldName, err)
		}
		optionalLines = append(optionalLines, *docs)
	}

	out := strings.Join(append(requiredLines, optionalLines...), "\n\n")
	return &out, nil
}

func documentationLineForArgument(field models.TerraformSchemaField, nestedWithin, resourceName string) (*string, error) {
	components := make([]string, 0)
	components = append(components, fmt.Sprintf("* `%s` -", field.HCLName))

	if field.Required {
		components = append(components, "(Required)")
	} else if field.Optional {
		components = append(components, "(Optional)")
	}

	isList := false
	if field.ObjectDefinition.Type == models.ListTerraformSchemaObjectDefinitionType || field.ObjectDefinition.Type == models.SetTerraformSchemaObjectDefinitionType {
		isList = true
	}
	objectDefinition := topLevelObjectDefinition(field.ObjectDefinition)

	// identify block
	if _, ok := objectDefinitionsWhichShouldBeSurfacedAsBlocks[objectDefinition.Type]; ok {
		fieldBeginsWithVowel, err := beginsWithVowel(field.HCLName)
		if err != nil {
			return nil, err
		}

		fieldLocation := "below"
		if nestedWithin != "" && field.HCLName <= nestedWithin {
			fieldLocation = "above"
		}

		if isList {
			components = append(components, fmt.Sprintf("A list of `%s` blocks as defined %s.", field.HCLName, fieldLocation))
		} else {
			if fieldBeginsWithVowel {
				components = append(components, fmt.Sprintf("An `%s` block as defined %s.", field.HCLName, fieldLocation))
			} else {
				components = append(components, fmt.Sprintf("A `%s` block as defined %s.", field.HCLName, fieldLocation))
			}
		}
	}

	components = append(components, field.Documentation.Markdown)

	if field.ObjectDefinition.Type == models.BooleanTerraformSchemaObjectDefinitionType {
		components = append(components, "Possible values are `true` and `false`.")
	} else if field.Validation != nil {
		if val, ok := field.Validation.(models.TerraformSchemaFieldValidationPossibleValuesDefinition); ok {
			if values := val.PossibleValues.Values; values != nil {
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
	return pointer.To(line), nil
}
