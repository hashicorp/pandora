using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePublicIPAddressDnsSettingsConfigurationSchema
{

    [HclName("domain_name_label")]
    [Required]
    public string DomainNameLabel { get; set; }

}
