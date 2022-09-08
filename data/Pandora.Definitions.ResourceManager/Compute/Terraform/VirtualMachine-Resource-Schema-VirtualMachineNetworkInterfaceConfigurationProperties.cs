using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineNetworkInterfaceConfigurationPropertiesSchema
{

    [HclName("accelerated_networking_enabled")]
    [Optional]
    public bool AcceleratedNetworkingEnabled { get; set; }


    [HclName("delete_option")]
    [Optional]
    public string DeleteOption { get; set; }


    [HclName("dns_settings")]
    [Optional]
    public VirtualMachineResourceVirtualMachineNetworkInterfaceDnsSettingsConfigurationSchema DnsSettings { get; set; }


    [HclName("dscp_configuration")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema DscpConfiguration { get; set; }


    [HclName("fpga_enabled")]
    [Optional]
    public bool FpgaEnabled { get; set; }


    [HclName("ip_configuration")]
    [Required]
    public List<VirtualMachineResourceVirtualMachineNetworkInterfaceIPConfigurationSchema> IPConfiguration { get; set; }


    [HclName("ip_forwarding_enabled")]
    [Optional]
    public bool IPForwardingEnabled { get; set; }


    [HclName("network_security_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema NetworkSecurityGroup { get; set; }


    [HclName("primary")]
    [Optional]
    public bool Primary { get; set; }

}
