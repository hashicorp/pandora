using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceTargetReferenceSchema
{

    [HclName("id")]
    [Required]
    public string Id { get; set; }


    [HclName("type")]
    [PossibleValuesFromConstant(typeof(v2022_07_01_preview.Experiments.TargetReferenceTypeConstant))]
    [Required]
    public string Type { get; set; }

}
