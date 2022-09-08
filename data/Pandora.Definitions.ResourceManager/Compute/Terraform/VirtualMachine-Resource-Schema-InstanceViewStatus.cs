using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceInstanceViewStatusSchema
{

    [HclName("code")]
    [Optional]
    public string Code { get; set; }


    [HclName("display_status")]
    [Optional]
    public string DisplayStatus { get; set; }


    [HclName("level")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.StatusLevelTypesConstant))]
    public string Level { get; set; }


    [HclName("message")]
    [Optional]
    public string Message { get; set; }


    [HclName("time")]
    [Optional]
    public System.DateTime Time { get; set; }

}
