using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkConfigurationSchema
{

    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetNetworkConfigurationPropertiesSchema> Properties { get; set; }

}
