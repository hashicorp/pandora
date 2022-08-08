using System;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResource : TerraformResourceDefinition
{
    public string DisplayName => "Resource Group";
    public ResourceID ResourceId => new v2020_06_01.ResourceGroups.ResourceGroupId();
    public string ResourceLabel => "resource_group";
    
    // TODO: add to the generator & System import
    public Type? SchemaModel => typeof(ResourceGroupResourceSchema);

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2020_06_01.ResourceGroups.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2020_06_01.ResourceGroups.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2020_06_01.ResourceGroups.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2020_06_01.ResourceGroups.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
