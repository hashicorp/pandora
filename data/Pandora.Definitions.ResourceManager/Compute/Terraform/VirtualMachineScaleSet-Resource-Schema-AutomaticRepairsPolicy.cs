using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceAutomaticRepairsPolicySchema
{

    [HclName("enabled")]
    [Optional]
    public bool Enabled { get; set; }


    [HclName("grace_period")]
    [Optional]
    public string GracePeriod { get; set; }


    [HclName("repair_action")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.RepairActionConstant))]
    public string RepairAction { get; set; }

}
