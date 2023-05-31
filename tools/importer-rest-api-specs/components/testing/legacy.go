package testing

import (
	"fmt"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/testattributes"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: this file needs refactoring

func generateTestConfig(providerPrefix, resourceLabel string, input resourcemanager.TerraformResourceDetails, requiredOnly bool, helper testattributes.TestAttributesHelpers) (*string, error) {
	f := hclwrite.NewEmptyFile()

	block := blockForResource(f, providerPrefix, resourceLabel, "test")
	if err := helper.GetAttributesForTests(resourceLabel, input.SchemaModels[input.SchemaModelName], block, requiredOnly); err != nil {
		return nil, err
	}

	output := string(hclwrite.Format(f.Bytes()))
	return &output, nil
}

func generateImportTestConfig(providerPrefix, resourceLabel string, input resourcemanager.TerraformResourceDetails, helper testattributes.TestAttributesHelpers) (*string, error) {
	f := hclwrite.NewEmptyFile()

	block := blockForResource(f, providerPrefix, resourceLabel, "import")
	if err := helper.GetAttributesForTests(resourceLabel, input.SchemaModels[input.SchemaModelName], block, true); err != nil {
		return nil, err
	}

	for hclName := range f.Body().Attributes() {
		f.Body().SetAttributeTraversal(hclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s_%s.test.%s", providerPrefix, resourceLabel, hclName),
			},
		})
	}

	output := string(hclwrite.Format(f.Bytes()))
	return &output, nil
}

func generateTestTemplate(dependencies testattributes.TestDependencyHelper) *string {
	components := make([]string, 0)
	if dependencies.Resource.HasEdgeZone {
		components = append(components, `
data "azurerm_extended_locations" "test" {
  location = azurerm_resource_group.test.location
}
`)
	}

	if dependencies.Resource.HasResourceGroup {
		components = append(components, `
resource "azurerm_resource_group" "test" {
  name     = "acctestrg-${local.random_integer}"
  location = local.primary_location
}
`)
	}

	// todo static or dynamic?
	if dependencies.Resource.HasPublicIP {
		components = append(components, `
resource "azurerm_public_ip" "test" {
  name                = "acctest-${local.random_integer}"
  location            = azurerm_resource_group.test.location
  resource_group_name = azurerm_resource_group.test.name
  allocation_method   = "Dynamic"
}
`)
	}

	if dependencies.Resource.HasUserAssignedIdentity {
		components = append(components, `
resource "azurerm_user_assigned_identity" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = azurerm_resource_group.test.name
  location            = azurerm_resource_group.test.location
}
`)
	}

	if dependencies.Resource.HasVirtualNetwork {
		components = append(components, `
resource "azurerm_virtual_network" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = azurerm_resource_group.test.name
  location            = azurerm_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`)
	}

	if dependencies.Resource.HasSubnet {
		components = append(components, `
resource "azurerm_subnet" "test" {
  name                 = "internal"
  resource_group_name  = azurerm_resource_group.test.name
  virtual_network_name = azurerm_virtual_network.test.name
  address_prefixes     = ["10.0.2.0/24"]
}
`)
	}

	// TODO: the features block should be moved to a per-test basis (except for RequiresImport, which uses the Basic tests)

	// TODO: conditionally add/remove variables to the format strings
	// for now whilst we have the ability to add the RandomInt/Location fields dynamically, let's hard code them
	// until we can conditionally add/remove variables to the format strings
	output := fmt.Sprintf(`
provider "azurerm" {
  features {}
}

locals {
  random_integer   = %%[1]d
  primary_location = %%[2]q
}

%s
`, strings.Join(components, "\n\n"))
	output = strings.Replace(output, "\"", "'", -1)
	return &output
}
