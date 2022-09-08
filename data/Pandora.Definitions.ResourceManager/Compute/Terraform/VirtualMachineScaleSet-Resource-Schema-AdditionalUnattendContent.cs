using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceAdditionalUnattendContentSchema
{

    [HclName("component_name")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.ComponentNamesConstant))]
    public string ComponentName { get; set; }


    [HclName("content")]
    [Optional]
    public string Content { get; set; }


    [HclName("pass_name")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.PassNamesConstant))]
    public string PassName { get; set; }


    [HclName("setting_name")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.SettingNamesConstant))]
    public string SettingName { get; set; }

}
