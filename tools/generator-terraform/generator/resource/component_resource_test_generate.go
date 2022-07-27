package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func generateResourceTests(input models.ResourceInput) string {
	if !input.Details.ReadMethod.Generate {
		return ""
	}

	testConfig := generateTestConfig(input.Models)

	return fmt.Sprintf(`
func TestAcc%[1]s_basic(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[2]s_%[3]s", "test")
	r := %[1]sResource{}

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
	r := %[1]sResource{}

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

func TestAcc%[1]s_complete(t *testing.T) {
	data := acceptance.BuildTestData(t, "%[2]s_%[3]s", "test")
	r := %[1]sResource{}

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
	r := %[1]sResource{}

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

func (%[1]sResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf(%[4]s)
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel, testConfig)
}

func generateTestConfig(models map[string]resourcemanager.ModelDetails) string{
	return "``"
}