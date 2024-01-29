// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterProjectResource : TerraformResourceDefinition
{
    public string DisplayName => "Dev Center Project";
    public ResourceID ResourceId => new v2023_04_01.Projects.ProjectId();
    public string ResourceLabel => "dev_center_project";
    public string ResourceCategory => "Dev Center";
    public string ResourceDescription => @"Manages a Dev Center Project";
    public string ResourceExampleUsage => @"resource 'azurerm_dev_center' 'example' {
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
  location            = azurerm_resource_group.example.location
  identity {
    type = 'example-value'
  }
}
resource 'azurerm_resource_group' 'example' {
  name     = 'example-resources'
  location = 'West Europe'
}
resource 'azurerm_dev_center_project' 'example' {
  dev_center_id       = azurerm_dev_center.example.id
  location            = azurerm_resource_group.example.location
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
}".AsTerraformTestConfig();
    public Type? SchemaModel => typeof(DevCenterProjectResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new DevCenterProjectResourceMappings();
    public TerraformResourceTestDefinition Tests => new DevCenterProjectResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.Projects.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.Projects.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.Projects.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.Projects.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
