using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceStepSchema
{

    [HclName("branch")]
    [Required]
    public List<ChaosStudioExperimentResourceBranchSchema> Branch { get; set; }


    [HclName("name")]
    [Required]
    public string Name { get; set; }

}
