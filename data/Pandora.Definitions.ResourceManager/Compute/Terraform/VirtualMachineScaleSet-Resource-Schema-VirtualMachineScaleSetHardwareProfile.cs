using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetHardwareProfileSchema
{

    [HclName("vm_size_properties")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVMSizePropertiesSchema> VmSizeProperties { get; set; }

}
