// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package examples

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestResourceExampleFromTests_NoTemplate_LoadTest(t *testing.T) {
	// Load Test is a special-case since the resource type contains the word `test`, validate
	// that this doesn't get transformed into `load_example`
	input := resourcemanager.TerraformResourceTestsDefinition{
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
	actual, err := ResourceExampleFromTests(input)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleFromTests_NoTemplate_InterpolatedValue(t *testing.T) {
	input := resourcemanager.TerraformResourceTestsDefinition{
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
	actual, err := ResourceExampleFromTests(input)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleFromTests_NoTemplate_ResourceGroup(t *testing.T) {
	input := resourcemanager.TerraformResourceTestsDefinition{
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
	actual, err := ResourceExampleFromTests(input)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleFromTests_WithTemplate_LoadTest(t *testing.T) {
	// Load Test is a special-case since the resource type contains the word `test`, validate
	// that this doesn't get transformed into `load_example`
	input := resourcemanager.TerraformResourceTestsDefinition{
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
	actual, err := ResourceExampleFromTests(input)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceExampleFromTests_WithTemplate_FleetMember(t *testing.T) {
	input := resourcemanager.TerraformResourceTestsDefinition{
		BasicConfiguration: `
resource "azurerm_kubernetes_fleet_member" "test" {
  kubernetes_cluster_id = azurerm_kubernetes_cluster.test.id
  kubernetes_fleet_id   = azurerm_kubernetes_fleet_manager.test.id
  name                  = "acctestkfm-${var.random_string}"
}
`,
		TemplateConfiguration: pointer.To(`
variable "primary_location" {}
variable "random_integer" {}
variable "random_string" {}

resource "azurerm_kubernetes_cluster" "test" {
  name                = "acctestaks${var.random_string}"
  location            = azurerm_resource_group.test.location
  resource_group_name = azurerm_resource_group.test.name
  dns_prefix          = "acctestaks${var.random_string}"

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_DS2_v2"
  }

  identity {
    type = "SystemAssigned"
  }
}


resource "azurerm_kubernetes_fleet_manager" "test" {
  name                = "acctestkfm${var.random_string}"
  location            = azurerm_resource_group.test.location
  resource_group_name = azurerm_resource_group.test.name
}


resource "azurerm_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`),
	}
	expected := `
resource "azurerm_kubernetes_cluster" "example" {
  name                = "example"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  dns_prefix          = "acctestaksexample"
  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_DS2_v2"
  }
  identity {
    type = "SystemAssigned"
  }
}
resource "azurerm_kubernetes_fleet_manager" "example" {
  name                = "example"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
}
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
resource "azurerm_kubernetes_fleet_member" "example" {
  kubernetes_cluster_id = azurerm_kubernetes_cluster.example.id
  kubernetes_fleet_id   = azurerm_kubernetes_fleet_manager.example.id
  name                  = "example"
}
`
	actual, err := ResourceExampleFromTests(input)
	if err != nil {
		t.Fatalf(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
