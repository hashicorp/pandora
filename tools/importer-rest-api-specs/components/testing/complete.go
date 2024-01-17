package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2/hclwrite"
)

func (tb TestBuilder) generateCompleteTest(dependencies *testDependencies) (*string, error) {
	f := hclwrite.NewEmptyFile()

	topLevelModel, ok := tb.details.SchemaModels[tb.details.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("the schema model %q was not found", tb.details.SchemaModelName)
	}

	completeRequired := false
	for _, details := range topLevelModel.Fields {
		if details.Required == false {
			completeRequired = true
			break
		}
	}

	if !completeRequired {
		return nil, nil
	}

	onlyRequiredFields := false // Compute should include all Required & Optional properties
	block, err := tb.getBlockValueForModel("resource", topLevelModel, dependencies, onlyRequiredFields, tb.details.Tests.TestData.CompleteVariables)
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
