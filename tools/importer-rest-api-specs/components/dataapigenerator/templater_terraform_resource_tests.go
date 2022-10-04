package dataapigenerator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceTestDefinition(terraformNamespace string, details resourcemanager.TerraformResourceDetails) string {
	basicConfig := prepareTerraformTestConfigForOutput(details.Tests.BasicConfiguration)
	requiresImportConfig := prepareTerraformTestConfigForOutput(details.Tests.RequiresImportConfiguration)
	completeConfig := conditionallyAddTestOutput(details.Tests.CompleteConfiguration)
	templateConfig := conditionallyAddTestOutput(details.Tests.TemplateConfiguration)

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace %[1]s;

public class %[2]sResourceTests : TerraformResourceTestDefinition
{
    public string BasicTestConfig => @"
%[3]s
    ".AsTerraformTestConfig();
    
    public string RequiresImportConfig => @"
%[4]s
    ".AsTerraformTestConfig();
    
    public string? CompleteConfig => %[5]s;
    public string? TemplateConfig => %[6]s;
    
    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
`, terraformNamespace, details.ResourceName, basicConfig, requiresImportConfig, completeConfig, templateConfig)
}

func conditionallyAddTestOutput(input *string) string {
	if input != nil {
		val := prepareTerraformTestConfigForOutput(*input)
		return fmt.Sprintf(`@"
%s
".AsTerraformTestConfig()`, val)
	}

	return "null"
}

func prepareTerraformTestConfigForOutput(input string) string {
	output := input
	output = strings.TrimSpace(output)
	output = strings.Replace(output, "\"", "'", -1)
	output = strings.TrimSpace(output)
	return output
}
