using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceAdditionalUnattendContentSchema
{

    [HclName("component_name")]
    [Optional]
    public string ComponentName { get; set; }


    [HclName("content")]
    [Optional]
    public string Content { get; set; }


    [HclName("pass_name")]
    [Optional]
    public string PassName { get; set; }


    [HclName("setting_name")]
    [Optional]
    public string SettingName { get; set; }

}
