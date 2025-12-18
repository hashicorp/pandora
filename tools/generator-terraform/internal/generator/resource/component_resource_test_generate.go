// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"sort"
	"strings"
	"unicode"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func codeForResourceTestFunctions(input models.ResourceInput) (*string, error) {
	if !input.Details.Tests.Generate {
		return nil, nil
	}

	functions := make([]string, 0)

	if input.Details.Tests.CompleteConfiguration != nil {
		functions = append(functions, fmt.Sprintf(`
func TestAcc%[1]s_complete(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[2]s_%[3]s", "test")
	r := %[1]sTestResource{}

	data.ResourceTest(t, r, []acceptance.TestStep{
		{
			Config: r.complete(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.ImportStep(),
	})
}

func TestAcc%[1]s_update(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[2]s_%[3]s", "test")
	r := %[1]sTestResource{}

	data.ResourceTest(t, r, []acceptance.TestStep{
		{
			Config: r.basic(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.ImportStep(),
		{
			Config: r.complete(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.ImportStep(),
		{
			Config: r.basic(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.ImportStep(),
	})
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel))
	}

	otherTestNames := make([]string, 0)
	if input.Details.Tests.OtherTests != nil {
		for testName := range *input.Details.Tests.OtherTests {
			otherTestNames = append(otherTestNames, testName)
		}
	}
	sort.Strings(otherTestNames)

	for _, testName := range otherTestNames {
		testConfigs := (*input.Details.Tests.OtherTests)[testName]
		testFunction := testForDynamicTestConfiguration(dynamicTestInput{
			providerPrefix:            input.ProviderPrefix,
			resourceLabel:             input.ResourceLabel,
			resourceName:              input.ResourceTypeName,
			testName:                  testName,
			dynamicTestConfigurations: testConfigs,
		})
		functions = append(functions, testFunction)
	}

	output := fmt.Sprintf(`
func TestAcc%[1]s_basic(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[2]s_%[3]s", "test")
	r := %[1]sTestResource{}

	data.ResourceTest(t, r, []acceptance.TestStep{
		{
			Config: r.basic(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.ImportStep(),
	})
}

func TestAcc%[1]s_requiresImport(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[2]s_%[3]s", "test")
	r := %[1]sTestResource{}

	data.ResourceTest(t, r, []acceptance.TestStep{
		{
			Config: r.basic(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.RequiresImportErrorStep(r.requiresImport),
	})
}

%[4]s
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel, strings.Join(functions, "\n"))
	return &output, nil
}

func codeForResourceTestConfigurationFunctions(input models.ResourceInput) (*string, error) {
	if !input.Details.Tests.Generate {
		return nil, nil
	}

	tests := input.Details.Tests

	template := ""
	templateVariables := ""
	if tests.TemplateConfiguration != nil {
		template = trimNewLinesAroundHclConfig(*tests.TemplateConfiguration)

		updatedTemplate, templatedVariables, err := updateTemplateWithVariableNames(template)
		if err != nil {
			return nil, fmt.Errorf("updating test template with variable names: %+v", err)
		}

		template = *updatedTemplate
		templateVariables = *templatedVariables
	}

	functions := make([]string, 0)
	if tests.CompleteConfiguration != nil {
		completeConfig := strings.TrimSpace(*tests.CompleteConfiguration)
		functions = append(functions, fmt.Sprintf(`
func (r %[1]sTestResource) complete(data acceptance.TestData) string {
	return fmt.Sprintf('
%%s

%[4]s
', r.template(data))
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel, completeConfig))
	}

	otherTestNames := make([]string, 0)
	if tests.OtherTests != nil {
		for testName := range *tests.OtherTests {
			otherTestNames = append(otherTestNames, testName)
		}
	}
	sort.Strings(otherTestNames)

	for _, testName := range otherTestNames {
		testConfigs := (*tests.OtherTests)[testName]
		testFunction := functionsForDynamicTestConfiguration(dynamicTestInput{
			providerPrefix:            input.ProviderPrefix,
			resourceLabel:             input.ResourceLabel,
			resourceName:              input.ResourceTypeName,
			testName:                  testName,
			dynamicTestConfigurations: testConfigs,
		})
		functions = append(functions, testFunction)
	}

	basicConfig := trimNewLinesAroundHclConfig(tests.BasicConfiguration)
	importConfig := trimNewLinesAroundHclConfig(tests.RequiresImportConfiguration)

	output := fmt.Sprintf(`
func (r %[1]sTestResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf('
%%s

%[2]s
', r.template(data))
}

func (r %[1]sTestResource) requiresImport(data acceptance.TestData) string {
	return fmt.Sprintf('
%%s

%[3]s
', r.basic(data))
}

%[4]s

func (r %[1]sTestResource) template(data acceptance.TestData) string {
	return fmt.Sprintf('
%[5]s
', %[6]s)
}
`, input.ResourceTypeName, basicConfig, importConfig, strings.Join(functions, "\n"), template, templateVariables)
	output = strings.ReplaceAll(output, "'", "`")
	return &output, nil
}

type dynamicTestInput struct {
	providerPrefix            string
	resourceLabel             string
	resourceName              string
	testName                  string
	dynamicTestConfigurations []string
}

func testForDynamicTestConfiguration(input dynamicTestInput) string {
	stages := make([]string, 0)

	for i := range input.dynamicTestConfigurations {
		nameForStage := input.testName
		if i > 0 {
			nameForStage = fmt.Sprintf("%s%d", nameForStage, i)
		}
		stage := fmt.Sprintf(`
		{
			Config: r.%[1]s(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
			),
		},
		data.ImportStep(),
`, nameForStage)
		stages = append(stages, stage)
	}

	return fmt.Sprintf(`
func TestAcc%[1]s_%[2]s(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[3]s_%[4]s", "test")
	r := %[1]sTestResource{}

	data.ResourceTest(t, r, []acceptance.TestStep{
		%[5]s
	})
}
`, input.resourceName, input.testName, input.providerPrefix, input.resourceLabel, strings.Join(stages, "\n"))
}

func functionsForDynamicTestConfiguration(input dynamicTestInput) string {
	configs := make([]string, 0)

	for i, config := range input.dynamicTestConfigurations {
		nameForStage := input.testName
		if i > 0 {
			nameForStage = fmt.Sprintf("%s%d", nameForStage, i)
		}

		stage := fmt.Sprintf(`
func (r %[1]sTestResource) %[2]s(data acceptance.TestData) string {
	return fmt.Sprintf('
%[3]s
', r.template(data))}
`, input.resourceName, nameForStage, config)
		configs = append(configs, stage)
	}

	return strings.Join(configs, "\n")
}

func trimNewLinesAroundHclConfig(body string) string {
	out := strings.TrimRightFunc(strings.Replace(body, "\t", "", -1), func(r rune) bool {
		return unicode.IsSpace(r)
	})

	out = strings.TrimLeftFunc(strings.Replace(out, "\t", "", -1), func(r rune) bool {
		return unicode.IsSpace(r)
	})

	return out
}
