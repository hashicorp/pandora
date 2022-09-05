using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineExtensionHandlerInstanceViewSchema
{

    [HclName("status")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Status { get; set; }


    [HclName("type")]
    [Optional]
    public string Type { get; set; }


    [HclName("type_handler_version")]
    [Optional]
    public string TypeHandlerVersion { get; set; }

}
