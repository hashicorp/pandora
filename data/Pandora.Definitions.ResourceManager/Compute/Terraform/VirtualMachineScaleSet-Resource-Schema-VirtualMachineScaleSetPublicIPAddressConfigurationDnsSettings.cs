using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetPublicIPAddressConfigurationDnsSettingsSchema
{

    [HclName("domain_name_label")]
    [Required]
    public string DomainNameLabel { get; set; }

}
