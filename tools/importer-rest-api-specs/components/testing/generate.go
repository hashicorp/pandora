package testing

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type TestBuilder struct {
	// providerPrefix is the prefix used for resources in this Terraform Provider (e.g. `azurerm`)
	providerPrefix string

	// resourceLabel is the label for this resource, without the providerPrefix (e.g. `load_test`)
	resourceLabel string

	// details is the Terraform Resource Details for this Resource
	details resourcemanager.TerraformResourceDetails
}

func NewTestBuilder(providerPrefix, resourceLabel string, details resourcemanager.TerraformResourceDetails) TestBuilder {
	return TestBuilder{
		providerPrefix: providerPrefix,
		resourceLabel:  resourceLabel,
		details:        details,
	}
}

// GenerateForResource builds a TerraformResourceTestsDefinition for the specified Terraform Resource
func (tb TestBuilder) GenerateForResource() (*resourcemanager.TerraformResourceTestsDefinition, error) {
	dependencies := testDependencies{
		variables: testVariables{},
	}
	basicConfig, err := tb.generateBasicTest(&dependencies)
	if err != nil {
		return nil, fmt.Errorf("generating basic test: %+v", err)
	}
	requiresImportConfig, err := tb.generateRequiresImportTest()
	if err != nil {
		return nil, fmt.Errorf("generating requires import test: %+v", err)
	}

	complete, err := tb.generateCompleteTest(&dependencies)
	if err != nil {
		return nil, fmt.Errorf("generating complete test: %+v", err)
	}

	templateConfig := tb.generateTemplateConfigForDependencies(dependencies)
	variablesConfig := generateTemplateForLocalVariables(dependencies.variables)
	templateConfig = fmt.Sprintf("%s\n%s", variablesConfig, templateConfig)

	out := resourcemanager.TerraformResourceTestsDefinition{
		BasicConfiguration:          *basicConfig,
		RequiresImportConfiguration: *requiresImportConfig,
		Generate:                    true,
		OtherTests:                  map[string][]string{},
		TemplateConfiguration:       &templateConfig,
		// TODO: we should split variables config out into it's own property too
	}

	// Complete is an Optional test, therefore only output it if it's needed
	if complete != nil {
		out.CompleteConfiguration = complete
	}

	return &out, nil
}
