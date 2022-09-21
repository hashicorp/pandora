using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ElasticSan.Terraform;

public class ElasticSanResourceSkuSchema
{

    [HclName("name")]
    [PossibleValuesFromConstant(typeof(v2021_11_20_preview.ElasticSans.SkuNameConstant))]
    [Required]
    public string Name { get; set; }


    [HclName("tier")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_20_preview.ElasticSans.SkuTierConstant))]
    public string Tier { get; set; }

}
