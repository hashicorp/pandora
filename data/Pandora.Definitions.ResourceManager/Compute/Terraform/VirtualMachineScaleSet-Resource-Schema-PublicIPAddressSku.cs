using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourcePublicIPAddressSkuSchema
{

    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("tier")]
    [Optional]
    public string Tier { get; set; }

}
