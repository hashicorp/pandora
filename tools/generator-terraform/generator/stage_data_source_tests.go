package generator

import (
	"fmt"
	"sort"
	"strings"
)

var _ stage = dataSourceTestsStage{}

type dataSourceTestsStage struct{}

func (d dataSourceTestsStage) applicable(data *Data) bool {
	return !data.IsResource && data.DataSourceTestCases != nil
}

func (d dataSourceTestsStage) filePath(data Data) string {
	return fmt.Sprintf("%s_test.go", data.fileNamePrefix)
}

func (d dataSourceTestsStage) generate(data Data) (*string, error) {
	testNames := make([]string, 0)
	for name := range data.DataSourceTestCases.Tests {
		testNames = append(testNames, name)
	}
	sort.Strings(testNames)

	testFuncs := make([]string, 0)
	for _, testName := range testNames {
		test := data.DataSourceTestCases.Tests[testName]

		stages := make([]string, 0)
		for i, stage := range test.Stages {
			if stage.ConfigName == nil {
				return nil, fmt.Errorf("missing ConfigName for Test Stage %d for %q", i, testName)
			}

			if stage.Import || stage.RequiresImport {
				return nil, fmt.Errorf("Import/RequiresImport can only be configured for a Resource")
			}

			stages = append(stages, fmt.Sprintf(`		{
			Config: ds.%[1]s(data),
			Check: acceptance.ComposeTestCheckFunc(
				// TODO: assertions
				// check.That(data.ResourceName).Key("is_online").HasValue("false"),
			),
		},`, *stage.ConfigName))
		}

		testFuncs = append(testFuncs, fmt.Sprintf(`
func TestAcc%[1]sDataSource_%[2]s(t *testing.T) {
	data := acceptance.BuildTestData(t, "data.%[3]s", "test")
	ds := %[1]sDataSourceTest{}
	data.DataSourceTest(t, []acceptance.TestStep{
%[4]s
	})
}
`, data.ResourceName, testName, data.ResourceType, strings.Join(stages, "\n")))
	}

	testConfigNames := make([]string, 0)
	for name := range data.DataSourceTestCases.Configs {
		testConfigNames = append(testConfigNames, name)
	}
	sort.Strings(testConfigNames)

	testConfigFuncs := make([]string, 0)
	for _, name := range testConfigNames {
		testConfig := data.DataSourceTestCases.Configs[name]
		backtick := "`"
		testConfigFuncs = append(testConfigFuncs, fmt.Sprintf(`
func (r %[1]sDataSourceTest) %[2]s(data acceptance.TestData) string {
	return fmt.Sprintf(%[4]s%[3]s%[4]s, data.RandomInteger, data.RandomString)
}
		`, data.ResourceName, name, testConfig.Config, backtick))
	}

	contents := fmt.Sprintf(`package %[1]s_test

import (
	"fmt"
	"testing"

	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/acceptance"
	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/acceptance/check"
)

type %[2]sDataSourceTest struct {
}

%[3]s
%[4]s
`, data.PackageName, data.ResourceName, strings.Join(testFuncs, "\n"), strings.Join(testConfigFuncs, "\n"))
	return &contents, nil
}
