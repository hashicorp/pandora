using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionProfileSchema
{

    [HclName("extension")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionSchema> Extension { get; set; }


    [HclName("extensions_time_budget")]
    [Optional]
    public string ExtensionsTimeBudget { get; set; }

}
