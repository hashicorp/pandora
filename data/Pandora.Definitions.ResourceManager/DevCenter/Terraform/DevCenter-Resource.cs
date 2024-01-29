// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterResource : TerraformResourceDefinition
{
    public string DisplayName => "Dev Center";
    public ResourceID ResourceId => new v2023_04_01.DevCenters.DevCenterId();
    public string ResourceLabel => "dev_center";
    public string ResourceCategory => "Dev Center";
    public string ResourceDescription => @"Manages a Dev Center";
    public string ResourceExampleUsage => @"resource 'azurerm_resource_group' 'example' {
  name     = 'example-resources'
  location = 'West Europe'
}
resource 'azurerm_user_assigned_identity' 'example' {
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
  location            = azurerm_resource_group.example.location
}
resource 'azurerm_dev_center' 'example' {
  location            = azurerm_resource_group.example.location
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
}".AsTerraformTestConfig();
    public Type? SchemaModel => typeof(DevCenterResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new DevCenterResourceMappings();
    public TerraformResourceTestDefinition Tests => new DevCenterResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.DevCenters.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.DevCenters.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.DevCenters.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_01.DevCenters.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
}
