using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineHealthStatusSchema
{

    [HclName("status")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Status { get; set; }

}
