using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePublicIPAddressConfigurationPropertiesSchema
{

    [HclName("delete_option")]
    [Optional]
    public string DeleteOption { get; set; }


    [HclName("dns_settings")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachinePublicIPAddressDnsSettingsConfigurationSchema> DnsSettings { get; set; }


    [HclName("ip_tag")]
    [Optional]
    public List<List<VirtualMachineResourceVirtualMachineIPTagSchema>> IPTag { get; set; }


    [HclName("idle_timeout_in_minutes")]
    [Optional]
    public int IdleTimeoutInMinutes { get; set; }


    [HclName("public_ip_address_version")]
    [Optional]
    public string PublicIPAddressVersion { get; set; }


    [HclName("public_ip_allocation_method")]
    [Optional]
    public string PublicIPAllocationMethod { get; set; }


    [HclName("public_ip_prefix_id")]
    [Optional]
    public List<VirtualMachineResourceSubResourceSchema> PublicIPPrefixId { get; set; }

}
