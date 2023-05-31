package testing

import (
	"fmt"
	"strings"
)

func (tb TestBuilder) generateTemplateConfigForDependencies(dependencies testDependencies) string {
	components := make([]string, 0)

	if dependencies.needsEdgeZone {
		components = append(components, fmt.Sprintf(`
data "%[1]s_extended_locations" "test" {
  location = %[1]s_resource_group.test.location
}
`, tb.providerPrefix))
	}

	if dependencies.needsPublicIP {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_public_ip" "test" {
  name                = "acctest-${local.random_integer}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name
  allocation_method   = "Static"
}
`, tb.providerPrefix))
	}

	if dependencies.needsResourceGroup {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`, tb.providerPrefix))
	}

	if dependencies.needsSubnet {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_subnet" "test" {
  name                 = "internal"
  resource_group_name  = %[1]s_resource_group.test.name
  virtual_network_name = %[1]s_virtual_network.test.name
  address_prefixes     = ["10.0.2.0/24"]
}
`, tb.providerPrefix))
	}

	if dependencies.needsUserAssignedIdentity {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_user_assigned_identity" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = %[1]s_resource_group.test.name
  location            = %[1]s_resource_group.test.location
}
`, tb.providerPrefix))
	}

	if dependencies.needsVirtualNetwork {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_virtual_network" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = %[1]s_resource_group.test.name
  location            = %[1]s_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`, tb.providerPrefix))
	}

	return strings.Join(components, "\n\n")
}
