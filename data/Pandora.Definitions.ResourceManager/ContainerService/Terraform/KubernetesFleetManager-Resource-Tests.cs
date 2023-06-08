using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesFleetManagerResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_kubernetes_fleet_manager' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctestkfm-${var.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}
    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
resource 'azurerm_kubernetes_fleet_manager' 'import' {
  location            = azurerm_kubernetes_fleet_manager.test.location
  name                = azurerm_kubernetes_fleet_manager.test.name
  resource_group_name = azurerm_kubernetes_fleet_manager.test.resource_group_name
}
    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_kubernetes_fleet_manager' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctestkfm-${var.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
  tags = {
    environment = 'terraform-acctests'
    some_key    = 'some-value'
  }
  hub_profile {
    dns_prefix = 'val-${var.random_string}'
  }
}
".AsTerraformTestConfig();
    public string? TemplateConfig => @"
variable 'primary_location' {}
variable 'random_integer' {}
variable 'random_string' {}

resource 'azurerm_resource_group' 'test' {
  name     = 'acctestrg-${var.random_integer}'
  location = var.primary_location
}
".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
