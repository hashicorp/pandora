using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourcePlanSchema
{

    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("product")]
    [Optional]
    public string Product { get; set; }


    [HclName("promotion_code")]
    [Optional]
    public string PromotionCode { get; set; }


    [HclName("publisher")]
    [Optional]
    public string Publisher { get; set; }

}
