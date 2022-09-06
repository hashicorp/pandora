using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceApiErrorSchema
{

    [HclName("code")]
    [Optional]
    public string Code { get; set; }


    [HclName("detail")]
    [Optional]
    public List<VirtualMachineResourceApiErrorBaseSchema> Detail { get; set; }


    [HclName("innererror")]
    [Optional]
    public VirtualMachineResourceInnerErrorSchema Innererror { get; set; }


    [HclName("message")]
    [Optional]
    public string Message { get; set; }


    [HclName("target")]
    [Optional]
    public string Target { get; set; }

}
