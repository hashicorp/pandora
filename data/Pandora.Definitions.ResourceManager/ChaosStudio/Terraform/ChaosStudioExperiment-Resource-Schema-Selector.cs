using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceSelectorSchema
{

    [HclName("id")]
    [Required]
    public string Id { get; set; }


    [HclName("target")]
    [Required]
    public List<ChaosStudioExperimentResourceTargetReferenceSchema> Target { get; set; }


    [HclName("type")]
    [PossibleValuesFromConstant(typeof(v2022_07_01_preview.Experiments.SelectorTypeConstant))]
    [Required]
    public string Type { get; set; }

}
