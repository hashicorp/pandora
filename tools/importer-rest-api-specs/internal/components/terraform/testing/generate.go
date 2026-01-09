// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

type testBuilder struct {
	// providerPrefix is the prefix used for resources in this Terraform Provider (e.g. `azurerm`)
	providerPrefix string

	// resourceLabel is the label for this resource, without the providerPrefix (e.g. `load_test`)
	resourceLabel string

	// details is the Terraform Resource Details for this Resource
	details sdkModels.TerraformResourceDefinition
}

func newTestBuilder(providerPrefix, resourceLabel string, details sdkModels.TerraformResourceDefinition) testBuilder {
	return testBuilder{
		providerPrefix: providerPrefix,
		resourceLabel:  resourceLabel,
		details:        details,
	}
}

// generateTestsForResource builds a TerraformResourceTestsDefinition for the specified Terraform Resource
func (tb testBuilder) generateTestsForResource(testData definitions.ResourceTestDataDefinition) (*sdkModels.TerraformResourceTestsDefinition, error) {
	dependencies := testDependencies{
		variables: testVariables{},
	}
	basicConfig, err := tb.generateBasicTest(&dependencies, testData)
	if err != nil {
		return nil, fmt.Errorf("generating basic test: %+v", err)
	}
	requiresImportConfig, err := tb.generateRequiresImportTest()
	if err != nil {
		return nil, fmt.Errorf("generating requires import test: %+v", err)
	}

	complete, err := tb.generateCompleteTest(&dependencies, testData)
	if err != nil {
		return nil, fmt.Errorf("generating complete test: %+v", err)
	}

	templateConfig := tb.generateTemplateConfigForDependencies(dependencies)
	variablesConfig := generateTemplateForLocalVariables(dependencies.variables)
	templateConfig = fmt.Sprintf("%s\n%s", variablesConfig, templateConfig)

	out := sdkModels.TerraformResourceTestsDefinition{
		BasicConfiguration:          *basicConfig,
		RequiresImportConfiguration: *requiresImportConfig,
		Generate:                    true,
		OtherTests:                  &map[string][]sdkModels.TerraformTestDefinition{},
		TemplateConfiguration:       &templateConfig,
		// TODO: we should split variables config out into it's own property too
	}

	// Complete is an Optional test, therefore only output it if it's needed
	if complete != nil {
		out.CompleteConfiguration = complete
	}

	return &out, nil
}
