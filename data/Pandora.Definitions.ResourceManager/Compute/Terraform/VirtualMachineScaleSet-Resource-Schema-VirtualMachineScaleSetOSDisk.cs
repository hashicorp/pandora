using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetOSDiskSchema
{

    [HclName("caching")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.CachingTypesConstant))]
    public string Caching { get; set; }


    [HclName("create_option")]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.DiskCreateOptionTypesConstant))]
    [Required]
    public string CreateOption { get; set; }


    [HclName("diff_disk_settings")]
    [Optional]
    public VirtualMachineScaleSetResourceDiffDiskSettingsSchema DiffDiskSettings { get; set; }


    [HclName("disk_size_gb")]
    [Optional]
    public int DiskSizeGB { get; set; }


    [HclName("image")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualHardDiskSchema Image { get; set; }


    [HclName("managed_disk")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetManagedDiskParametersSchema ManagedDisk { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("os_type")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.OperatingSystemTypesConstant))]
    public string OsType { get; set; }


    [HclName("vhd_container")]
    [Optional]
    public List<string> VhdContainer { get; set; }


    [HclName("write_accelerator_enabled")]
    [Optional]
    public bool WriteAcceleratorEnabled { get; set; }

}
