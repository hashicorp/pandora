using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceLinuxPatchSettingsSchema
{

    [HclName("assessment_mode")]
    [Optional]
    public string AssessmentMode { get; set; }


    [HclName("patch_mode")]
    [Optional]
    public string PatchMode { get; set; }

}
