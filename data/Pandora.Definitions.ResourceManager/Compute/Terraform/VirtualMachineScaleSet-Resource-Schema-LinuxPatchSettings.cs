using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceLinuxPatchSettingsSchema
{

    [HclName("assessment_mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.LinuxPatchAssessmentModeConstant))]
    public string AssessmentMode { get; set; }


    [HclName("patch_mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.LinuxVMGuestPatchModeConstant))]
    public string PatchMode { get; set; }

}
