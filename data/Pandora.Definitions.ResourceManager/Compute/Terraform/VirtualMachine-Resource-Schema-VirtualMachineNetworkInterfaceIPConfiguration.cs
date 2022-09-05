using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineNetworkInterfaceIPConfigurationSchema
{

    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineNetworkInterfaceIPConfigurationPropertiesSchema> Properties { get; set; }

}
