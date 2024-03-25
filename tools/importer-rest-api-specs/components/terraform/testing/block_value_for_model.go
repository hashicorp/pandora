// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (tb TestBuilder) getBlockValueForModel(hclName string, model resourcemanager.TerraformSchemaModelDefinition, dependencies *testDependencies, onlyRequiredFields bool, testData resourcemanager.TerraformTestDataVariables) (*hclwrite.Block, error) {
	block := hclwrite.NewBlock(hclName, []string{})
	fields := getRequiredFieldsForSchemaModel(model)
	if !onlyRequiredFields {
		optionalFields := getOptionalFieldsForSchemaModel(model)
		fields = append(fields, optionalFields...)
	}

	for _, nestedField := range fields {
		if needsBlock(nestedField.ObjectDefinition.Type, nestedField.ObjectDefinition.NestedObject) {
			nestedBlocks, err := tb.getBlockValueForField(nestedField, dependencies, onlyRequiredFields, testData)
			if err != nil {
				return nil, fmt.Errorf("getting block value for field %q: %+v", nestedField.HclName, err)
			}
			for _, item := range *nestedBlocks {
				block.Body().AppendBlock(item)
			}

			continue
		}

		attributeVal, err := tb.getAttributeValueForField(nestedField, dependencies, testData)
		if err != nil {
			return nil, fmt.Errorf("getting attribute value for field %q: %+v", nestedField.HclName, err)
		}
		block.Body().SetAttributeRaw(nestedField.HclName, *attributeVal)
	}

	return block, nil
}
