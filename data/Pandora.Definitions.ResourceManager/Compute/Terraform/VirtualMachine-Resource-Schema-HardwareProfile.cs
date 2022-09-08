using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceHardwareProfileSchema
{

    [HclName("vm_size")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.VirtualMachineSizeTypesConstant))]
    public string VmSize { get; set; }


    [HclName("vm_size_properties")]
    [Optional]
    public VirtualMachineResourceVMSizePropertiesSchema VmSizeProperties { get; set; }

}
