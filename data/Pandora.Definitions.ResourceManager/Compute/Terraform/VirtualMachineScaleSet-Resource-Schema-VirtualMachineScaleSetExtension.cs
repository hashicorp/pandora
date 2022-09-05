using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionSchema
{

    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionPropertiesSchema> Properties { get; set; }


    [HclName("type")]
    [Optional]
    public string Type { get; set; }

}
