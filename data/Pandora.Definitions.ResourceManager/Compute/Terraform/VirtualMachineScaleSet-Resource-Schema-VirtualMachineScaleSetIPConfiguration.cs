using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetIPConfigurationSchema
{

    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetIPConfigurationPropertiesSchema Properties { get; set; }

}
