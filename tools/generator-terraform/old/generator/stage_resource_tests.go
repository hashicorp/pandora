package generator

import (
	"fmt"
	"sort"
	"strings"
)

var _ stage = resourceTestsStage{}

type resourceTestsStage struct{}

func (d resourceTestsStage) applicable(data *Data) bool {
	return data.IsResource && data.ResourceTestCases != nil
}

func (d resourceTestsStage) filePath(data Data) string {
	return fmt.Sprintf("%s_test.go", data.fileNamePrefix)
}

func (d resourceTestsStage) generate(data Data) (*string, error) {
	testNames := make([]string, 0)
	for name := range data.ResourceTestCases.Tests {
		testNames = append(testNames, name)
	}
	sort.Strings(testNames)

	testFuncs := make([]string, 0)
	for _, testName := range testNames {
		test := data.ResourceTestCases.Tests[testName]

		stages := make([]string, 0)
		for i, stage := range test.Stages {
			if stage.RequiresImport {
				stages = append(stages, fmt.Sprintf("\t\tdata.RequiresImportErrorStep(r.%[1]s),", *stage.ConfigName))
				continue
			}
			if stage.Import {
				stages = append(stages, "\t\tdata.ImportStep(),")
				continue
			}

			if stage.ConfigName == nil {
				return nil, fmt.Errorf("missing ConfigName for Test Stage %d for %q", i, testName)
			}

			stages = append(stages, fmt.Sprintf(`		{
			Config: r.%[1]s(data),
			Check: acceptance.ComposeTestCheckFunc(
				check.That(data.ResourceName).ExistsInAzure(r),
				// TODO: assertions
			),
		},`, *stage.ConfigName))
		}

		testFuncs = append(testFuncs, fmt.Sprintf(`
func TestAcc%[1]sResource_%[2]s(t *testing.T) {
	data := acceptance.BuildTestData(t, "data.%[3]s", "test")
	r := %[1]sResourceTest{}
	data.ResourceTest(t, r, []acceptance.TestStep{
%[4]s
	})
}
`, data.ResourceName, testName, data.ResourceType, strings.Join(stages, "\n")))
	}

	testConfigNames := make([]string, 0)
	for name := range data.ResourceTestCases.Configs {
		testConfigNames = append(testConfigNames, name)
	}
	sort.Strings(testConfigNames)

	testConfigFuncs := make([]string, 0)
	for _, name := range testConfigNames {
		testConfig := data.ResourceTestCases.Configs[name]
		backtick := "`"
		testConfigFuncs = append(testConfigFuncs, fmt.Sprintf(`
func (r %[1]sResourceTest) %[2]s(data acceptance.TestData) string {
	return fmt.Sprintf(%[4]s%[3]s%[4]s, data.RandomInteger, data.RandomString)
}
		`, data.ResourceName, name, testConfig.Config, backtick))
	}

	existsFunc := fmt.Sprintf(`
func (r %[2]sResourceTest) Exists(ctx context.Context, client *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := gosdk.%[3]sID(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.%[4]s.%[5]s(ctx, *id)
	if err != nil {
		return nil, fmt.Errorf("checking if %%s exists: %%+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`, data.PackageName, data.ResourceName, *data.ResourceIDTypeName, data.ClientName, data.ResourceReadOperation.SDKMethodName)

	contents := fmt.Sprintf(`package %[1]s_test

import (
	"fmt"
	"testing"

	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/acceptance"
	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/acceptance/check"
	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/clients"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
)

type %[2]sResourceTest struct {
}

%[3]s
%[4]s
%[5]s
`, data.PackageName, data.ResourceName, strings.Join(testFuncs, "\n"), existsFunc, strings.Join(testConfigFuncs, "\n"))
	return &contents, nil
}
