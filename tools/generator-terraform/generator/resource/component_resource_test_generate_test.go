package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestGenerateBasicTest_RegularResourceId_Enabled(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		ResourceLabel:    "example",
		ProviderPrefix:   "azurerm",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:   true,
				MethodName: "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
		},
	}
	actual, err := generateResourceTests(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.ReplaceAll(`
func TestAccExample_basic(t *testing.T) {
	data := acceptance.BuildTestData(t, "azurerm_example", "test")
	r := ExampleTestResource{}

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

func TestAccExample_requiresImport(t *testing.T) {
	data := acceptance.BuildTestData(t, "azurerm_example", "test")
	r := ExampleTestResource{}

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

func TestAccExample_complete(t *testing.T) {
	data := acceptance.BuildTestData(t, "azurerm_example", "test")
	r := ExampleTestResource{}

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

func TestAccExample_update(t *testing.T) {
	data := acceptance.BuildTestData(t, "azurerm_example", "test")
	r := ExampleTestResource{}

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

func (ExampleTestResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf('
resource "azurerm_example" "test" {
  name = "acctest-%s"
}
', data.RandomString)}

func (r ExampleTestResource) requiresImport(data acceptance.TestData) string {
	return fmt.Sprintf('
%s

resource "azurerm_example" "import" {

}
', r.basic(data))}

func (ExampleTestResource) complete(data acceptance.TestData) string {
	return fmt.Sprintf('
resource "azurerm_example" "test" {
  name = "acctest-%s"
}
', data.RandomString)}
`, "'", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
