package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestGenerateBasicTest_RegularResourceId_Enabled(t *testing.T) {
	input := ResourceInput{
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
	expected := `
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
`
	assertTemplatedCodeMatches(t, expected, actual)
}
