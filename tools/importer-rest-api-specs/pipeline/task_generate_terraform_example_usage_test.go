package pipeline

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// TODO: this should likely be refactored into a Component, but refactoring this usage for now

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
		{
			input: `
resource "azurerm_load_test" "test" {
  name     = "example-resources"
  location = "West Europe"
}
`,
			expected: `
resource "azurerm_load_test" "example" {
  name     = "example-resources"
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
