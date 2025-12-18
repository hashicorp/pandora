// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForAttributesReference(input generatorModels.ResourceInput) (*string, error) {

	components := make([]string, 0)
	components = append(components, "## Attributes Reference")
	components = append(components, "In addition to the Arguments listed above - the following Attributes are exported:")
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

func getAttributes(model models.TerraformSchemaModel) (*string, error) {
	lines := make([]string, 0)
	sortedFieldNames := sortFieldNamesAlphabetically(model)

	for _, fieldName := range sortedFieldNames {
		field := model.Fields[fieldName]
		if field.Computed && !field.Optional && !field.Required {
			line, err := documentationLineForAttribute(field, "")
			if err != nil {
				return nil, fmt.Errorf("building documentation line for attribute field %q: %+v", fieldName, err)
			}
			lines = append(lines, *line)
		}
	}
	out := strings.Join(append(lines), "\n\n")
	return &out, nil
}

func documentationLineForAttribute(field models.TerraformSchemaField, nestedWithin string) (*string, error) {
	components := make([]string, 0)
	components = append(components, fmt.Sprintf("* `%s` -", field.HCLName))

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

	line := removeExtraSpaces(strings.Join(components, " "))
	return &line, nil
}
