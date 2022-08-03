package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func generateResourceTests(input models.ResourceInput) (*string, error) {
	if !input.Details.ReadMethod.Generate {
		return nil, nil
	}

	//todo add generated test attributes

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

func (%[1]sTestResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf('
resource "%[2]s_%[3]s" "test" {
	name = "acctest-%%s"
}
', data.RandomString)}

func (r %[1]sTestResource) requiresImport(data acceptance.TestData) string {
	return fmt.Sprintf('
%%s

resource "%[2]s_%[3]s" "import" {
}
', r.basic(data))}

func (%[1]sTestResource) complete(data acceptance.TestData) string {
	return fmt.Sprintf('
resource "%[2]s_%[3]s" "test" {
	name = "acctest-%%s"
}
', data.RandomString)}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel)
	output = strings.ReplaceAll(output, "'", "`")
	return &output, nil
}
