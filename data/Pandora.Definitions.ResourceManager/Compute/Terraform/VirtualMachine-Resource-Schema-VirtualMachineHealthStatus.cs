using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineHealthStatusSchema
{

    [HclName("status")]
    public VirtualMachineResourceInstanceViewStatusSchema Status { get; set; }

}
