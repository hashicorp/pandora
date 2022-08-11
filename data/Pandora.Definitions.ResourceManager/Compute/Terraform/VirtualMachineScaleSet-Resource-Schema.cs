using System.Collections.Generic;
using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSchema
{
    // TODO: populate with a real schema

    [HclName("location")]
    [ForceNew]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [HclName("name")]
    [ForceNew]
    [Required]
    [Description("The name of this Virtual Machine Scale Set.")]
    public string Name { get; set; }

    [HclName("resource_group_name")]
    [ForceNew]
    [Required]
    [Description("The name of the Resource Group where this Virtual Machine Scale Set should exist.")]
    public string ResourceGroupName { get; set; }

    [HclName("tags")]
    [Optional]
    public CustomTypes.Tags Tags { get; set; }

    [HclName("overprovision")]
    [Optional]
    public bool Overprovision { get; set; }

    [HclName("proximity_placement_group_id")]
    [Optional]
    public string ProximityPlacementGroupId { get; set; }

    [HclName("unique_id")]
    [Optional]
    public string UniqueId { get; set; }

    [HclName("data_disks")]
    [Optional]
    public List<VirtualMachineScaleSetDataDiskSchemaModel> DataDisks { get; set; }
}

public class VirtualMachineScaleSetDataDiskSchemaModel
{
    [HclName("name")]
    [Required]
    public string Name { get; set; }
}
