using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceTests : TerraformResourceTestDefinition
{
    // TODO: output real tests
    public string BasicTestConfig => @"
         
resource 'azurerm_chaos_studio_experiment' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name

  selector {
    id = 'foo'

    target {
      id   = 'foo'
      type = 'foo'
    }

    type = 'foo'
  }


  step {

    branch {

      action {
        name = 'acctest-${local.random_integer}'
        type = 'foo'
      }

      name = 'acctest-${local.random_integer}'
    }

    name = 'acctest-${local.random_integer}'
  }

}


    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
         
resource 'azurerm_chaos_studio_experiment' 'import' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name

  selector {
    id = 'foo'

    target {
      id   = 'foo'
      type = 'foo'
    }

    type = 'foo'
  }


  step {

    branch {

      action {
        name = 'acctest-${local.random_integer}'
        type = 'foo'
      }

      name = 'acctest-${local.random_integer}'
    }

    name = 'acctest-${local.random_integer}'
  }

}


    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"

resource 'azurerm_chaos_studio_experiment' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name

  selector {
    id = 'foo'

    target {
      id   = 'foo'
      type = 'foo'
    }

    type = 'foo'
  }


  step {

    branch {

      action {
        name = 'acctest-${local.random_integer}'
        type = 'foo'
      }

      name = 'acctest-${local.random_integer}'
    }

    name = 'acctest-${local.random_integer}'
  }


  identity {
    type = 'SystemAssigned'
  }

  start_on_creation = false
  tags = {
    env  = 'Production'
    test = 'Acceptance'
  }
}


	".AsTerraformTestConfig();
    public string? TemplateConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
