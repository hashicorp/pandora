// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2/hclwrite"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func (tb testBuilder) generateCompleteTest(dependencies *testDependencies, testData definitions.ResourceTestDataDefinition) (*string, error) {
	f := hclwrite.NewEmptyFile()

	topLevelModel, ok := tb.details.SchemaModels[tb.details.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("the schema model %q was not found", tb.details.SchemaModelName)
	}

	completeRequired := hasOptionalField(topLevelModel.Fields, tb.details.SchemaModels)

	if !completeRequired {
		return nil, nil
	}

	onlyRequiredFields := false // Compute should include all Required & Optional properties
	block, err := tb.getBlockValueForModel("resource", topLevelModel, dependencies, onlyRequiredFields, testData.CompleteVariables)
	if err != nil {
		return nil, fmt.Errorf("retrieving block value for top-level model %q: %+v", tb.details.SchemaModelName, err)
	}
	// add the labels needed to make this block a Terraform resource
	block.SetLabels([]string{
		fmt.Sprintf("%s_%s", tb.providerPrefix, tb.resourceLabel),
		"test",
	})
	f.Body().AppendBlock(block)

	testBody := hclwrite.Format(f.Bytes())
	providerBlock, err := tb.generateProviderBlock(dependencies)
	if err != nil {
		return nil, fmt.Errorf("generating the provider block: %+v", err)
	}

	out := fmt.Sprintf(`
%s
%s
`, *providerBlock, testBody)
	return &out, nil
}

func hasOptionalField(input map[string]sdkModels.TerraformSchemaField, schemaModels map[string]sdkModels.TerraformSchemaModel) bool {
	for _, details := range input {
		if details.ObjectDefinition.NestedObject != nil {
			if details.ObjectDefinition.NestedObject.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
				nestedModel := schemaModels[*details.ObjectDefinition.NestedObject.ReferenceName]
				if hasOptionalField(nestedModel.Fields, schemaModels) {
					return true
				}
			}
		}
		if details.Required != true {
			return true
		}
	}
	return false
}
