// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

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
	requiredAttributeNames := make([]string, 0)
	requiredBlockNames := make([]string, 0)
	for fieldName, field := range input.Fields {
		if !field.Required {
			continue
		}

		if needsBlock(field.ObjectDefinition.Type, field.ObjectDefinition.NestedObject) {
			requiredBlockNames = append(requiredBlockNames, fieldName)
		} else {
			requiredAttributeNames = append(requiredAttributeNames, fieldName)
		}
	}
	sort.Strings(requiredAttributeNames)
	sort.Strings(requiredBlockNames)

	out := make([]resourcemanager.TerraformSchemaFieldDefinition, 0)
	for _, fieldName := range requiredAttributeNames {
		field := input.Fields[fieldName]
		out = append(out, field)
	}
	for _, fieldName := range requiredBlockNames {
		field := input.Fields[fieldName]
		out = append(out, field)
	}

	return out
}

func getOptionalFieldsForSchemaModel(input resourcemanager.TerraformSchemaModelDefinition) []resourcemanager.TerraformSchemaFieldDefinition {
	// TODO: should we force `name`, `location` and `resource_group_name` at the top?

	attributeFieldNames := make([]string, 0)
	blockFieldNames := make([]string, 0)
	for fieldName, field := range input.Fields {
		if !field.Optional {
			continue
		}

		if needsBlock(field.ObjectDefinition.Type, field.ObjectDefinition.NestedObject) {
			blockFieldNames = append(blockFieldNames, fieldName)
		} else {
			attributeFieldNames = append(attributeFieldNames, fieldName)
		}
	}
	sort.Strings(attributeFieldNames)
	sort.Strings(blockFieldNames)

	out := make([]resourcemanager.TerraformSchemaFieldDefinition, 0)
	for _, fieldName := range attributeFieldNames {
		field := input.Fields[fieldName]
		out = append(out, field)
	}
	for _, fieldName := range blockFieldNames {
		field := input.Fields[fieldName]
		out = append(out, field)
	}

	return out
}

func needsBlock(input resourcemanager.TerraformSchemaFieldType, nestedObject *resourcemanager.TerraformSchemaFieldObjectDefinition) bool {
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

	if _, ok := typesNeedingBlocks[input]; ok {
		// TODO add support for list of ints
		// lists of basic types should be treated as attributes rather than blocks
		if nestedObject != nil && nestedObject.Type == resourcemanager.TerraformSchemaFieldTypeString {
			return false
		}
		return true
	}
	return false
}

func suffixFromResourceLabel(input string) string {
	vals := make([]string, 0)

	for _, val := range strings.Split(input, "_") {
		vals = append(vals, string(val[0]))
	}

	return strings.Join(vals, "")
}

// TODO this currently only works for top level properties - we should extend this use the path to the field e.g. foo.bar
func findTestDataValue[V any](field string, m map[string]V) *V {
	for k, v := range m {
		if strings.EqualFold(field, k) {
			return &v
		}
	}
	return nil
}
