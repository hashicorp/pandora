using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetStorageProfileSchema
{

    [HclName("data_disk")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetDataDiskSchema> DataDisk { get; set; }


    [HclName("image_reference")]
    [Optional]
    public VirtualMachineScaleSetResourceImageReferenceSchema ImageReference { get; set; }


    [HclName("os_disk")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetOSDiskSchema OsDisk { get; set; }

}
