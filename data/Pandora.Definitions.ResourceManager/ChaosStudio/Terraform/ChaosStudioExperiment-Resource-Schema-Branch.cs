using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceBranchSchema
{

    [HclName("action")]
    [Required]
    public List<ChaosStudioExperimentResourceActionSchema> Action { get; set; }


    [HclName("name")]
    [Required]
    public string Name { get; set; }

}
