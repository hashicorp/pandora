using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceTests : TerraformResourceTestDefinition
{
    // TODO: output real tests
    public string BasicTestConfig => @"
         
resource 'azurerm_resource_group' 'test' {
  location = azurerm_resource_group.test.location
  name     = azurerm_resource_group.test.name
}


    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
         
resource 'azurerm_resource_group' 'import' {
  location = azurerm_resource_group.test.location
  name     = azurerm_resource_group.test.name
}


    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"

resource 'azurerm_resource_group' 'test' {
  location = azurerm_resource_group.test.location
  name     = azurerm_resource_group.test.name
  tags = {
    env  = 'Production'
    test = 'Acceptance'
  }
}


	",AsTerraformTestConfig();
    public string? TemplateConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
