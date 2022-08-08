using System;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResource : TerraformResourceDefinition
{
    public string DisplayName => "Virtual Machine";
    public ResourceID ResourceId => new v2021_11_01.VirtualMachines.VirtualMachineId();
    public string ResourceLabel => "virtual_machine";
    
    public Type? SchemaModel => typeof(VirtualMachineResourceSchema);

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachines.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachines.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachines.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachines.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
