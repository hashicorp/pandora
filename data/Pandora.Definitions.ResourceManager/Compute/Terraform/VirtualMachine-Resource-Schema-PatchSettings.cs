using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourcePatchSettingsSchema
{

    [HclName("assessment_mode")]
    [Optional]
    public string AssessmentMode { get; set; }


    [HclName("hotpatching_enabled")]
    [Optional]
    public bool HotpatchingEnabled { get; set; }


    [HclName("patch_mode")]
    [Optional]
    public string PatchMode { get; set; }

}
