using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceDataDiskSchema
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


    [HclName("detach_option")]
    [Optional]
    public string DetachOption { get; set; }


    [HclName("disk_iops_read_write")]
    [Optional]
    public int DiskIOPSReadWrite { get; set; }


    [HclName("disk_m_bps_read_write")]
    [Optional]
    public int DiskMBpsReadWrite { get; set; }


    [HclName("disk_size_gb")]
    [Optional]
    public int DiskSizeGB { get; set; }


    [HclName("image")]
    [Optional]
    public VirtualMachineResourceVirtualHardDiskSchema Image { get; set; }


    [HclName("lun")]
    [Required]
    public int Lun { get; set; }


    [HclName("managed_disk")]
    [Optional]
    public VirtualMachineResourceManagedDiskParametersSchema ManagedDisk { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("to_be_detached")]
    [Optional]
    public bool ToBeDetached { get; set; }


    [HclName("vhd")]
    [Optional]
    public VirtualMachineResourceVirtualHardDiskSchema Vhd { get; set; }


    [HclName("write_accelerator_enabled")]
    [Optional]
    public bool WriteAcceleratorEnabled { get; set; }

}
