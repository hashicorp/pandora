package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestGenerateBasicTest_RegularResourceId_Enabled(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		ResourceLabel: "example",
		ProviderPrefix: "azurerm",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
		},
	}
	actual := strings.TrimSpace(generateResourceTests(input))
	expected := fmt.Sprintf(`
func TestAccExample_basic(t *testing.T) {
	data := acceptance.BuildTestData(t, "azurerm_example", "test")
	r := ExampleResource{}

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
	r := ExampleResource{}

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
	r := ExampleResource{}

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
	r := ExampleResource{}

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

func (ExampleResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf(%s)
}
`, basicTestConfig)
	assertTemplatedCodeMatches(t, expected, actual)
}

var basicTestConfig =  "``"