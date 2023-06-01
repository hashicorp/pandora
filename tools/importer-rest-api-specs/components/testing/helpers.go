package testing

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"sort"

	"github.com/hashicorp/hcl/v2/hclwrite"
)

func blockForResource(f *hclwrite.File, providerPrefix, resourceLabel, resourceLabelType string) *hclwrite.Body {
	fullResourceLabel := fmt.Sprintf("%s_%s", providerPrefix, resourceLabel)
	return f.Body().AppendNewBlock("resource", []string{
		fullResourceLabel,
		resourceLabelType,
	}).Body()
}

func getRequiredFieldsForSchemaModel(input resourcemanager.TerraformSchemaModelDefinition) []resourcemanager.TerraformSchemaFieldDefinition {
	// TODO: should we force `name`, `location` and `resource_group_name` at the top?

	fieldNames := make([]string, 0)
	for fieldName, field := range input.Fields {
		if !field.Required {
			continue
		}

		fieldNames = append(fieldNames, fieldName)
	}
	sort.Strings(fieldNames)

	out := make([]resourcemanager.TerraformSchemaFieldDefinition, 0)
	for _, fieldName := range fieldNames {
		field := input.Fields[fieldName]
		out = append(out, field)
	}

	return out
}

func needsBlock(input resourcemanager.TerraformSchemaFieldDefinition) bool {
	typesNeedingBlocks := map[resourcemanager.TerraformSchemaFieldType]struct{}{
		resourcemanager.TerraformSchemaFieldTypeList:      {},
		resourcemanager.TerraformSchemaFieldTypeReference: {},
		resourcemanager.TerraformSchemaFieldTypeSet:       {},

		// NOTE: the following CommonSchema types are exposed as Blocks and not Attributes (valid under `terraform-plugin-sdk@v2` / protocol v5)
		// however this'll change in the future under `terraform-plugin-framework` / protocol v6
		resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:        {},
		resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: {},
		resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:  {},
		resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:          {},
	}
	_, ok := typesNeedingBlocks[input.ObjectDefinition.Type]
	return ok
}
