// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2/hclwrite"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func (tb testBuilder) getBlockValueForModel(hclName string, model sdkModels.TerraformSchemaModel, dependencies *testDependencies, onlyRequiredFields bool, testData definitions.VariablesDefinition) (*hclwrite.Block, error) {
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
				return nil, fmt.Errorf("getting block value for field %q: %+v", nestedField.HCLName, err)
			}
			for _, item := range *nestedBlocks {
				block.Body().AppendBlock(item)
			}

			continue
		}

		attributeVal, err := tb.getAttributeValueForField(nestedField, dependencies, testData)
		if err != nil {
			return nil, fmt.Errorf("getting attribute value for field %q: %+v", nestedField.HCLName, err)
		}
		block.Body().SetAttributeRaw(nestedField.HCLName, *attributeVal)
	}

	return block, nil
}
