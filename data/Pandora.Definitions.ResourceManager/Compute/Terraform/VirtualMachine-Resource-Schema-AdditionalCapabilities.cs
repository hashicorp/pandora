using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceAdditionalCapabilitiesSchema
{

    [HclName("hibernation_enabled")]
    [Optional]
    public bool HibernationEnabled { get; set; }


    [HclName("ultra_ssdenabled")]
    [Optional]
    public bool UltraSSDEnabled { get; set; }

}
