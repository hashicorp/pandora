using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
resource 'azurerm_resource_group' 'test' {
  location = '${local.primary_location}'
  name     = 'acctestrg-${local.random_integer}'
}
    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
resource 'azurerm_resource_group' 'import' {
  location = '${local.primary_location}'
  name     = 'acctestrg-${local.random_integer}'
}
    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"
resource 'azurerm_resource_group' 'test' {
  location = '${local.primary_location}'
  name     = 'acctestrg-${local.random_integer}'
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
".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
