using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceApiErrorBaseSchema
{

    [HclName("code")]
    [Optional]
    public string Code { get; set; }


    [HclName("message")]
    [Optional]
    public string Message { get; set; }


    [HclName("target")]
    [Optional]
    public string Target { get; set; }

}
