package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (g PandoraDefinitionGenerator) GenerateTerraformResourceDefinition(fileName, terraformNamespace, resourceNamespace, resourceLabel string, details resourcemanager.TerraformResourceDetails) error {
	code := codeForTerraformDefinition(terraformNamespace, resourceNamespace, resourceLabel, details)
	return writeToFile(fileName, code)
}

func codeForTerraformDefinition(terraformNamespace, resourceNamespace, resourceLabel string, details resourcemanager.TerraformResourceDetails) string {
	components := []string{
		templateForTerraformMethodDefinition("Create", details.CreateMethod, false, resourceNamespace),
		templateForTerraformMethodDefinition("Delete", details.DeleteMethod, false, resourceNamespace),
		templateForTerraformMethodDefinition("Read", details.ReadMethod, false, resourceNamespace),
	}

	updateCode := "public MethodDefinition? UpdateMethod => null"
	if details.UpdateMethod != nil {
		updateCode = templateForTerraformMethodDefinition("Update", *details.UpdateMethod, true, resourceNamespace)
	}
	components = append(components, updateCode)

	return fmt.Sprintf(`
using Pandora.Definitions.Interfaces;

namespace %[1]s;

public class %[2]sResource : TerraformResourceDefinition
{
    public string DisplayName => "%[3]s";
    public ResourceID ResourceId => new %[4]s.%[5]s();
    public string ResourceLabel => "%[6]s";

    public bool GenerateIDValidationFunction => true;
    public bool GenerateSchema => true;

    %[7]s
}
`, terraformNamespace, details.ResourceName, details.DisplayName, resourceNamespace, details.ResourceIdName, resourceLabel, strings.Join(components, "\n"))
}

func templateForTerraformMethodDefinition(methodName string, method resourcemanager.MethodDefinition, nullable bool, resourceNamespace string) string {
	returnType := "MethodDefinition"
	if nullable {
		returnType = "MethodDefinition?"
	}
	return fmt.Sprintf(`
    public %[1]s %[2]sMethod => new MethodDefinition
    {
        Generate = %[3]t,
        Method = typeof(%[4]s.%[5]sOperation),
        TimeoutInMinutes = %[6]d,
    };
`, returnType, methodName, method.Generate, resourceNamespace, method.MethodName, method.TimeoutInMinutes)
}
