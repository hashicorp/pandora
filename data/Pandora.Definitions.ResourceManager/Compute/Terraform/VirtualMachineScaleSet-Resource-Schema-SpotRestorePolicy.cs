using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSpotRestorePolicySchema
{

    [HclName("restore_timeout")]
    [Optional]
    public string RestoreTimeout { get; set; }


    [HclName("d_enabled")]
    [Optional]
    public bool dEnabled { get; set; }

}
