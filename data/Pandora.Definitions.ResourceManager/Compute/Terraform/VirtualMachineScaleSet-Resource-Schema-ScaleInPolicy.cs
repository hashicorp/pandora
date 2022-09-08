using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceScaleInPolicySchema
{

    [HclName("force_deletion")]
    [Optional]
    public bool ForceDeletion { get; set; }


    [HclName("rule")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.VirtualMachineScaleSetScaleInRulesConstant))]
    public List<string> Rule { get; set; }

}
