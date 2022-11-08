using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.Terraform;

public class UserAssignedIdentityResource : TerraformResourceDefinition
{
    public string DisplayName => "User Assigned Identity";
    public ResourceID ResourceId => new v2022_01_31_preview.ManagedIdentities.UserAssignedIdentityId();
    public string ResourceLabel => "user_assigned_identity";
    public string ResourceCategory => "Authorization";
    public string ResourceDescription => @"Manages a User Assigned Identity";
    public string ResourceExampleUsage => @"resource 'azurerm_user_assigned_identity' 'example' {
  location            = azurerm_resource_group.example.location
  name                = 'example'
  resource_group_name = azurerm_resource_group.example.name
}".AsTerraformTestConfig();
    public Type? SchemaModel => typeof(UserAssignedIdentityResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new UserAssignedIdentityResourceMappings();
    public TerraformResourceTestDefinition Tests => new UserAssignedIdentityResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_01_31_preview.ManagedIdentities.UserAssignedIdentitiesCreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_01_31_preview.ManagedIdentities.UserAssignedIdentitiesDeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_01_31_preview.ManagedIdentities.UserAssignedIdentitiesGetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_01_31_preview.ManagedIdentities.UserAssignedIdentitiesUpdateOperation),
        TimeoutInMinutes = 30,
    };
}
