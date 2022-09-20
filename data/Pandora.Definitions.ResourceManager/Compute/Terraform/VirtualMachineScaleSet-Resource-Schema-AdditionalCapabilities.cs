using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceAdditionalCapabilitiesSchema
{

    [HclName("hibernation_enabled")]
    [Optional]
    public bool HibernationEnabled { get; set; }


    [HclName("ultra_ssd_enabled")]
    [Optional]
    public bool UltraSSDEnabled { get; set; }

}
