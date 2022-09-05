using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetOSDiskSchema
{

    [HclName("caching")]
    [Optional]
    public string Caching { get; set; }


    [HclName("create_option")]
    [Required]
    public string CreateOption { get; set; }


    [HclName("diff_disk_settings")]
    [Optional]
    public List<VirtualMachineScaleSetResourceDiffDiskSettingsSchema> DiffDiskSettings { get; set; }


    [HclName("disk_size_gb")]
    [Optional]
    public int DiskSizeGB { get; set; }


    [HclName("image")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualHardDiskSchema> Image { get; set; }


    [HclName("managed_disk")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetManagedDiskParametersSchema> ManagedDisk { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("os_type")]
    [Optional]
    public string OsType { get; set; }


    [HclName("vhd_container")]
    [Optional]
    public List<string> VhdContainer { get; set; }


    [HclName("write_accelerator_enabled")]
    [Optional]
    public bool WriteAcceleratorEnabled { get; set; }

}
