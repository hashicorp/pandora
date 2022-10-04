using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.Terraform;

public class LoadTestResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
resource 'azurerm_load_test' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}
    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
resource 'azurerm_load_test' 'import' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}
    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"
resource 'azurerm_load_test' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
  description         = 'foo'

  identity {
    type = 'SystemAssigned'
  }

  tags = {
    env  = 'Production'
    test = 'Acceptance'
  }
}
".AsTerraformTestConfig();
    public string? TemplateConfig => @"
provider 'azurerm' {
  features {}
}

locals {
  random_integer   = %[1]d
  primary_location = %[2]q
}


resource 'azurerm_resource_group' 'test' {
  name     = 'acctestrg-${local.random_integer}'
  location = local.primary_location
}
".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
