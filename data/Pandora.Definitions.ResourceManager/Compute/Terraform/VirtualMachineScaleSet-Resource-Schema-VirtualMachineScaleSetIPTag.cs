using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetIPTagSchema
{

    [HclName("ip_tag_type")]
    [Optional]
    public string IPTagType { get; set; }


    [HclName("tag")]
    [Optional]
    public string Tag { get; set; }

}
