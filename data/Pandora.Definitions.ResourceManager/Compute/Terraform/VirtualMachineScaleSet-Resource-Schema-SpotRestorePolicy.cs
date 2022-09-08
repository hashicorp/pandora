using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSpotRestorePolicySchema
{

    [HclName("enabled")]
    [Optional]
    public bool Enabled { get; set; }


    [HclName("restore_timeout")]
    [Optional]
    public string RestoreTimeout { get; set; }

}
