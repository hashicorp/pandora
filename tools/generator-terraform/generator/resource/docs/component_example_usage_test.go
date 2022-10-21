package docs

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestExampleUsage(t *testing.T) {
	input := models.ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
			Documentation: resourcemanager.ResourceDocumentationDefinition{
				ExampleUsageHcl: `
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
`,
			},
		},
	}
	actual, err := codeForExampleUsage(input)
	if err != nil {
		t.Fatalf("expected no error but got one: %+v", err)
	}
	expected := strings.ReplaceAll(`
## Example Usage

'''hcl
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
'''
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
