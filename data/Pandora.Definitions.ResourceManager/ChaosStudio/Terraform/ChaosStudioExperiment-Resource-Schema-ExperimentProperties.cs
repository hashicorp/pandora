using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceExperimentPropertiesSchema
{

    [HclName("selector")]
    [Required]
    public List<ChaosStudioExperimentResourceSelectorSchema> Selector { get; set; }


    [HclName("start_on_creation")]
    [Optional]
    public bool StartOnCreation { get; set; }


    [HclName("step")]
    [Required]
    public List<ChaosStudioExperimentResourceStepSchema> Step { get; set; }

}
