using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceStorageProfileSchema
{

    [HclName("data_disk")]
    [Optional]
    public List<List<VirtualMachineResourceDataDiskSchema>> DataDisk { get; set; }


    [HclName("image_reference")]
    [Optional]
    public List<VirtualMachineResourceImageReferenceSchema> ImageReference { get; set; }


    [HclName("os_disk")]
    [Optional]
    public List<VirtualMachineResourceOSDiskSchema> OsDisk { get; set; }

}
