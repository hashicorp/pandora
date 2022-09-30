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
			Tests: resourcemanager.TerraformResourceTestsDefinition{
				BasicConfiguration: `
resource "azurerm_resource_group" "test" {
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

func TestConvertBasicTestToUsableExample(t *testing.T) {
	testData := []struct {
		input    string
		expected string
	}{
		{
			input: `
resource "azurerm_resource_group" "test" {
  name     = "example-resources"
  location = "West Europe"
}
`,
			expected: `
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
`,
		},
		{
			input: `
resource "azurerm_resource_group" "test" {
  name     = "acctest-${local.random_integer}"
  location = "${local.primary_location}"
}
`,
			expected: `
resource "azurerm_resource_group" "example" {
  name     = "example"
  location = "West Europe"
}
`,
		},
		{
			input: `
resource "azurerm_resource_group" "test" {
  name     = "example${local.random_integer}"
  location = "${local.primary_location}"
}
`,
			expected: `
resource "azurerm_resource_group" "example" {
  name     = "example21"
  location = "West Europe"
}
`,
		},
	}
	for _, v := range testData {
		t.Logf("Testing Input %q", v.input)
		input := resourcemanager.TerraformResourceTestsDefinition{
			BasicConfiguration: v.input,
		}
		actual := convertBasicTestToUsableExample(input)
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, actual)
	}
}
