using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceDiffDiskSettingsSchema
{

    [HclName("option")]
    [Optional]
    public string Option { get; set; }


    [HclName("placement")]
    [Optional]
    public string Placement { get; set; }

}
