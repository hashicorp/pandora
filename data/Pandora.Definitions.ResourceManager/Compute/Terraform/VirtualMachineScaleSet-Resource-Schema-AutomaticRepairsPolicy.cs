using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceAutomaticRepairsPolicySchema
{

    [HclName("grace_period")]
    [Optional]
    public string GracePeriod { get; set; }


    [HclName("repair_action")]
    [Optional]
    public string RepairAction { get; set; }


    [HclName("d_enabled")]
    [Optional]
    public bool dEnabled { get; set; }

}
