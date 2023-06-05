using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.Terraform;

public class UserAssignedIdentityResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_user_assigned_identity' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctestuai-${var.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}
    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
resource 'azurerm_user_assigned_identity' 'import' {
  resource_group_name = azurerm_user_assigned_identity.test.resource_group_name
  name                = azurerm_user_assigned_identity.test.name
  location            = azurerm_user_assigned_identity.test.location
}
    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"
provider 'azurerm' {
  features {}
}

resource 'azurerm_user_assigned_identity' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctestuai-${var.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
  tags = {
    environment = 'terraform-acctests'
    some_key    = 'some-value'
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
