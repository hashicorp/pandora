using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.Terraform;

public class LoadTestResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_load_test' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctestlt-${var.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}
    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
resource 'azurerm_load_test' 'import' {
  name                = azurerm_load_test.test.name
  location            = azurerm_load_test.test.location
  resource_group_name = azurerm_load_test.test.resource_group_name
}
    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_load_test' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctestlt-${var.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
  description         = 'Description for the Load Test'
  tags = {
    environment = 'terraform-acctests'
    some_key    = 'some-value'
  }
  identity {
    type = 'SystemAssigned'
  }
}
".AsTerraformTestConfig();
    public string? TemplateConfig => @"
variable 'primary_location' {}
variable 'random_integer' {}

resource 'azurerm_resource_group' 'test' {
  name     = 'acctestrg-${var.random_integer}'
  location = var.primary_location
}
".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
