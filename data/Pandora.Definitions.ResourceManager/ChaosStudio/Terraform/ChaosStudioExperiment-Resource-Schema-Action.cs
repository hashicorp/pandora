using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceActionSchema
{

    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [HclName("type")]
    [Required]
    public string Type { get; set; }

}
