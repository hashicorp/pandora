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

func getAttributes(model resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
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

func documentationLineForAttribute(field resourcemanager.TerraformSchemaFieldDefinition, nestedWithin string) (*string, error) {
	components := make([]string, 0)
	components = append(components, fmt.Sprintf("* `%s` -", field.HclName))

	isList := false
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList || field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeSet {
		isList = true
	}
	objectDefinition := topLevelObjectDefinition(field.ObjectDefinition)

	// identify block
	if _, ok := objectDefinitionsWhichShouldBeSurfacedAsBlocks[objectDefinition.Type]; ok {
		fieldBeginsWithVowel, err := beginsWithVowel(field.HclName)
		if err != nil {
			return nil, err
		}

		fieldLocation := "below"
		if nestedWithin != "" && field.HclName <= nestedWithin {
			fieldLocation = "above"
		}

		if isList {
			components = append(components, fmt.Sprintf("A list of `%s` blocks as defined %s.", field.HclName, fieldLocation))
		} else {
			if fieldBeginsWithVowel {
				components = append(components, fmt.Sprintf("An `%s` block as defined %s.", field.HclName, fieldLocation))
			} else {
				components = append(components, fmt.Sprintf("A `%s` block as defined %s.", field.HclName, fieldLocation))
			}
		}
	}
	components = append(components, field.Documentation.Markdown)

	line := removeExtraSpaces(strings.Join(components, " "))
	return &line, nil
}
