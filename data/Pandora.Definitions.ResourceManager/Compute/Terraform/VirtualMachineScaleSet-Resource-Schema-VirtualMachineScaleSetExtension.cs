using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionSchema
{

    [Computed]
    [HclName("id")]
    public string Id { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetExtensionPropertiesSchema Properties { get; set; }


    [Computed]
    [HclName("type")]
    public string Type { get; set; }

}
