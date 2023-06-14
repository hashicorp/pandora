using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.Terraform;

public class LoadTestResource : TerraformResourceDefinition
{
    public string DisplayName => "Load Test";
    public ResourceID ResourceId => new v2022_12_01.LoadTests.LoadTestId();
    public string ResourceLabel => "load_test";
    public string ResourceCategory => "Load Test";
    public string ResourceDescription => @"Manages a Load Test Service";
    public string ResourceExampleUsage => @"resource 'azurerm_resource_group' 'example' {
  name     = 'example-resources'
  location = 'West Europe'
}
resource 'azurerm_user_assigned_identity' 'example' {
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
  location            = azurerm_resource_group.example.location
}
resource 'azurerm_load_test' 'example' {
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
        Method = typeof(v2022_12_01.LoadTests.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_12_01.LoadTests.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_12_01.LoadTests.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_12_01.LoadTests.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
