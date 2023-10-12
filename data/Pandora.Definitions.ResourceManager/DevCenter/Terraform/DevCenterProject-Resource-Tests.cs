using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterProjectResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_dev_center_project' 'test' {
  dev_center_id       = azurerm_dev_center.test.id
  location            = azurerm_resource_group.test.location
  name                = 'acctestdcp-${var.random_string}'
  resource_group_name = azurerm_resource_group.test.name
}
    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
resource 'azurerm_dev_center_project' 'import' {
  dev_center_id       = azurerm_dev_center_project.test.dev_center_id
  location            = azurerm_dev_center_project.test.location
  name                = azurerm_dev_center_project.test.name
  resource_group_name = azurerm_dev_center_project.test.resource_group_name
}
    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_dev_center_project' 'test' {
  dev_center_id          = azurerm_dev_center.test.id
  location               = azurerm_resource_group.test.location
  name                   = 'acctestdcp-${var.random_string}'
  resource_group_name    = azurerm_resource_group.test.name
  description            = 'Description for the Dev Center Project'
  max_dev_boxes_per_user = 21
  tags = {
    environment = 'terraform-acctests'
    some_key    = 'some-value'
  }
}
".AsTerraformTestConfig();
    public string? TemplateConfig => @"
variable 'primary_location' {}
variable 'random_integer' {}
variable 'random_string' {}

resource 'azurerm_dev_center' 'test' {
  name                = 'acctestdc-${var.random_string}'
  resource_group_name = azurerm_resource_group.test.name
  location            = azurerm_resource_group.test.location

  identity {
    type = 'SystemAssigned'
  }
}


resource 'azurerm_resource_group' 'test' {
  name     = 'acctestrg-${var.random_integer}'
  location = var.primary_location
}
".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
