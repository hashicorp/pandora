using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceStorageProfileSchema
{

    [HclName("data_disk")]
    [Optional]
    public List<VirtualMachineResourceDataDiskSchema> DataDisk { get; set; }


    [HclName("image_reference")]
    [Optional]
    public VirtualMachineResourceImageReferenceSchema ImageReference { get; set; }


    [HclName("os_disk")]
    [Optional]
    public VirtualMachineResourceOSDiskSchema OsDisk { get; set; }

}
