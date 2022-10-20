using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.Terraform;

public class LoadTestResource : TerraformResourceDefinition
{
    public string DisplayName => "Load Test";
    public ResourceID ResourceId => new v2021_12_01_preview.LoadTests.LoadTestId();
    public string ResourceLabel => "load_test";
    public string ResourceCategory => "Load Test";
    public string ResourceDescription => "Manages a Load Test Service";
    public string ResourceExampleUsage => @"resource 'azurerm_load_example' 'example' {
  location            = azurerm_resource_group.example.location
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
}".AsTerraformTestConfig();
    public Type? SchemaModel => typeof(LoadTestResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new LoadTestResourceMappings();
    public TerraformResourceTestDefinition Tests => new LoadTestResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_12_01_preview.LoadTests.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_12_01_preview.LoadTests.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_12_01_preview.LoadTests.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_12_01_preview.LoadTests.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
