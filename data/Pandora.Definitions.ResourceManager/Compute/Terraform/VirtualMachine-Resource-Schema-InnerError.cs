using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceInnerErrorSchema
{

    [HclName("errordetail")]
    [Optional]
    public string Errordetail { get; set; }


    [HclName("exceptiontype")]
    [Optional]
    public string Exceptiontype { get; set; }

}
