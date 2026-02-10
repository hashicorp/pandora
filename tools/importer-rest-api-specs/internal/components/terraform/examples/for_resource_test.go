// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package examples

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestResourceExampleForResource_NoTemplate_LoadTest(t *testing.T) {
	t.Parallel(
	// Load Test is a special-case since the resource type contains the word `test`, validate
	// that this doesn't get transformed into `load_example`
	)

	input := sdkModels.TerraformResourceTestsDefinition{
		BasicConfiguration: `
resource "azurerm_load_test" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`,
	}
	expected := `
resource "azurerm_load_test" "example" {
  name     = "example"
  location = "West Europe"
}
`
	actual, err := exampleUsageForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleFromTests_NoTemplate_InterpolatedValue(t *testing.T) {
	t.Parallel()
	input := sdkModels.TerraformResourceTestsDefinition{
		BasicConfiguration: `
resource "azurerm_some_resource" "test" {
  some_field = "some-${var.random_string}-num-${var.random_integer}-loc-${var.primary_location}"
}
`,
	}
	expected := `
resource "azurerm_some_resource" "example" {
  some_field = "some-example-num-21-loc-West Europe"
}
`
	actual, err := exampleUsageForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleForResource_NoTemplate_ResourceGroup(t *testing.T) {
	t.Parallel()
	input := sdkModels.TerraformResourceTestsDefinition{
		BasicConfiguration: `
resource "azurerm_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`,
	}
	expected := `
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
`
	actual, err := exampleUsageForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleForResource_WithTemplate_LoadTest(t *testing.T) {
	t.Parallel(
	// Load Test is a special-case since the resource type contains the word `test`, validate
	// that this doesn't get transformed into `load_example`
	)

	input := sdkModels.TerraformResourceTestsDefinition{
		BasicConfiguration: `
resource "azurerm_load_test" "test" {
  name     = "acctest-${var.random_integer}"
  location = azurerm_resource_group.test.location
}
`,
		TemplateConfiguration: pointer.To(`
variable "random_integer" {}

resource "azurerm_resource_group" "example" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`),
	}
	expected := `
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}

resource "azurerm_load_test" "example" {
  name     = "example"
  location = azurerm_resource_group.example.location
}
`
	actual, err := exampleUsageForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
