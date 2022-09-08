using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSkuSchema
{

    [HclName("capacity")]
    [Optional]
    public int Capacity { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("tier")]
    [Optional]
    public string Tier { get; set; }

}
