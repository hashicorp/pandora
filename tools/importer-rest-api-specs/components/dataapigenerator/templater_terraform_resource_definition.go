package dataapigenerator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceDefinition(terraformNamespace, apiVersion, apiResource, resourceLabel string, details resourcemanager.TerraformResourceDetails) string {
	components := []string{
		templateForTerraformMethodDefinition("Create", details.CreateMethod, false, apiVersion, apiResource),
		templateForTerraformMethodDefinition("Delete", details.DeleteMethod, false, apiVersion, apiResource),
		templateForTerraformMethodDefinition("Read", details.ReadMethod, false, apiVersion, apiResource),
	}

	updateCode := "public MethodDefinition? UpdateMethod => null;"
	if details.UpdateMethod != nil {
		updateCode = templateForTerraformMethodDefinition("Update", *details.UpdateMethod, true, apiVersion, apiResource)
	}
	components = append(components, updateCode)

	exampleUsage := prepareTerraformTestConfigForOutput(details.Documentation.ExampleUsageHcl)

	return fmt.Sprintf(`using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace %[1]s;

public class %[2]sResource : TerraformResourceDefinition
{
    public string DisplayName => "%[3]s";
    public ResourceID ResourceId => new %[4]s.%[5]s.%[6]s();
    public string ResourceLabel => "%[7]s";
    public string ResourceCategory => "%[10]s";
    public string ResourceDescription => "%[9]s";
    public string ResourceExampleUsage => @"%[11]s".AsTerraformTestConfig();
    public Type? SchemaModel => typeof(%[2]sResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new %[2]sResourceMappings();
    public TerraformResourceTestDefinition Tests => new %[2]sResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    %[8]s
}
`, terraformNamespace, details.ResourceName, details.DisplayName, apiVersion, apiResource, details.ResourceIdName, resourceLabel, strings.Join(components, "\n"), details.Documentation.Description, details.Documentation.Category, exampleUsage)
}

func templateForTerraformMethodDefinition(methodName string, method resourcemanager.MethodDefinition, nullable bool, apiVersion, apiResource string) string {
	returnType := "MethodDefinition"
	if nullable {
		returnType = "MethodDefinition?"
	}
	return strings.TrimSpace(fmt.Sprintf(`
    public %[1]s %[2]sMethod => new MethodDefinition
    {
        Generate = %[3]t,
        Method = typeof(%[4]s.%[5]s.%[6]sOperation),
        TimeoutInMinutes = %[7]d,
    };
`, returnType, methodName, method.Generate, apiVersion, apiResource, method.MethodName, method.TimeoutInMinutes))
}
