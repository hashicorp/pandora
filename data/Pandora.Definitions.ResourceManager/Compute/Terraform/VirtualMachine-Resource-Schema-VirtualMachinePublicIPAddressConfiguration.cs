using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePublicIPAddressConfigurationSchema
{

    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachinePublicIPAddressConfigurationPropertiesSchema> Properties { get; set; }


    [HclName("sku")]
    [Optional]
    public List<VirtualMachineResourcePublicIPAddressSkuSchema> Sku { get; set; }

}
