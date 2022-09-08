using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourcePublicIPAddressSkuSchema
{

    [HclName("name")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.PublicIPAddressSkuNameConstant))]
    public string Name { get; set; }


    [HclName("tier")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.PublicIPAddressSkuTierConstant))]
    public string Tier { get; set; }

}
