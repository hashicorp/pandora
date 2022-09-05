using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceNetworkInterfaceReferenceSchema
{

    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("properties")]
    [Optional]
    public List<VirtualMachineResourceNetworkInterfaceReferencePropertiesSchema> Properties { get; set; }

}
