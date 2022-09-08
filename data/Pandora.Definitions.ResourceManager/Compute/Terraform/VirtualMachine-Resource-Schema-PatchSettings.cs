using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourcePatchSettingsSchema
{

    [HclName("assessment_mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.WindowsPatchAssessmentModeConstant))]
    public string AssessmentMode { get; set; }


    [HclName("hotpatching_enabled")]
    [Optional]
    public bool HotpatchingEnabled { get; set; }


    [HclName("patch_mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.WindowsVMGuestPatchModeConstant))]
    public string PatchMode { get; set; }

}
