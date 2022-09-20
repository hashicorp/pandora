using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetDataDiskSchema
{

    [HclName("caching")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.CachingTypesConstant))]
    public string Caching { get; set; }


    [HclName("create_option")]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.DiskCreateOptionTypesConstant))]
    [Required]
    public string CreateOption { get; set; }


    [HclName("disk_iops_read_write")]
    [Optional]
    public int DiskIOPSReadWrite { get; set; }


    [HclName("disk_mbps_read_write")]
    [Optional]
    public int DiskMBpsReadWrite { get; set; }


    [HclName("disk_size_gb")]
    [Optional]
    public int DiskSizeGB { get; set; }


    [HclName("lun")]
    [Required]
    public int Lun { get; set; }


    [HclName("managed_disk")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetManagedDiskParametersSchema ManagedDisk { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("write_accelerator_enabled")]
    [Optional]
    public bool WriteAcceleratorEnabled { get; set; }

}
