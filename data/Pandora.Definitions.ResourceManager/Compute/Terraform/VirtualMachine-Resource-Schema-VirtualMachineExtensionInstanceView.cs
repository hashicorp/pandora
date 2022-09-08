using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineExtensionInstanceViewSchema
{

    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("statuse")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Statuse { get; set; }


    [HclName("substatuse")]
    [Optional]
    public List<VirtualMachineResourceInstanceViewStatusSchema> Substatuse { get; set; }


    [HclName("type")]
    [Optional]
    public string Type { get; set; }


    [HclName("type_handler_version")]
    [Optional]
    public string TypeHandlerVersion { get; set; }

}
