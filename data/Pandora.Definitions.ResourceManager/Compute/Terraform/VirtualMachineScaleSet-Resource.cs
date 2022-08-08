using System;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResource : TerraformResourceDefinition
{
    public string DisplayName => "Virtual Machine Scale Set";
    public ResourceID ResourceId => new v2021_11_01.VirtualMachineScaleSets.VirtualMachineScaleSetId();
    public string ResourceLabel => "virtual_machine_scale_set";
    public Type? SchemaModel => typeof(VirtualMachineScaleSetResourceSchema);

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachineScaleSets.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachineScaleSets.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachineScaleSets.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_01.VirtualMachineScaleSets.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
