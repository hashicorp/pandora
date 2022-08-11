package dataapigenerator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceTestDefinition(terraformNamespace string, details resourcemanager.TerraformResourceDetails) string {
	// TODO: schema models are available in details.SchemaModels
	// TODO: the main schema name is available in details.SchemaModelName

	// TODO: output the real tests - NOTE these needs to change `"` for `'` (which gets converted back in .AsTerraformTestConfig())
	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace %[1]s;

public class %[2]sResourceTests : TerraformResourceTestDefinition
{
	// TODO: output real tests
    public string BasicTestConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();
    
    public string RequiresImportConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();
    
    public string? CompleteConfig => null;
    public string? TemplateConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();
    
    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
`, terraformNamespace, details.ResourceName)
}
