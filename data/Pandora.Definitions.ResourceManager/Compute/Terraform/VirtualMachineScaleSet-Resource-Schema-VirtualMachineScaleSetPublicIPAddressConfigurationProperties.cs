using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetPublicIPAddressConfigurationPropertiesSchema
{

    [HclName("delete_option")]
    [Optional]
    public string DeleteOption { get; set; }


    [HclName("dns_settings")]
    [Optional]
    public VirtualMachineScaleSetResourceVirtualMachineScaleSetPublicIPAddressConfigurationDnsSettingsSchema DnsSettings { get; set; }


    [HclName("ip_tag")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetIPTagSchema> IPTag { get; set; }


    [HclName("idle_timeout_in_minutes")]
    [Optional]
    public int IdleTimeoutInMinutes { get; set; }


    [HclName("public_ip_address_version")]
    [Optional]
    public string PublicIPAddressVersion { get; set; }


    [HclName("public_ip_prefix")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema PublicIPPrefix { get; set; }

}
