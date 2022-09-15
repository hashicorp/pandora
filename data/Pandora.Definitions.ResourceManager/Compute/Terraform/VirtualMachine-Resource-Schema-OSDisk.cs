using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceOSDiskSchema
{

    [HclName("caching")]
    [Optional]
    public string Caching { get; set; }


    [HclName("create_option")]
    [Required]
    public string CreateOption { get; set; }


    [HclName("delete_option")]
    [Optional]
    public string DeleteOption { get; set; }


    [HclName("diff_disk_settings")]
    [Optional]
    public VirtualMachineResourceDiffDiskSettingsSchema DiffDiskSettings { get; set; }


    [HclName("disk_size_gb")]
    [Optional]
    public int DiskSizeGB { get; set; }


    [HclName("encryption_settings")]
    [Optional]
    public VirtualMachineResourceDiskEncryptionSettingsSchema EncryptionSettings { get; set; }


    [HclName("image")]
    [Optional]
    public VirtualMachineResourceVirtualHardDiskSchema Image { get; set; }


    [HclName("managed_disk")]
    [Optional]
    public VirtualMachineResourceManagedDiskParametersSchema ManagedDisk { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("os_type")]
    [Optional]
    public string OsType { get; set; }


    [HclName("vhd")]
    [Optional]
    public VirtualMachineResourceVirtualHardDiskSchema Vhd { get; set; }


    [HclName("write_accelerator_enabled")]
    [Optional]
    public bool WriteAcceleratorEnabled { get; set; }

}
