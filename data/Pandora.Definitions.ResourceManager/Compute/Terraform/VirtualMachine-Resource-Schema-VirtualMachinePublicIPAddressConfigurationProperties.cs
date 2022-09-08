using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachinePublicIPAddressConfigurationPropertiesSchema
{

    [HclName("delete_option")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.DeleteOptionsConstant))]
    public string DeleteOption { get; set; }


    [HclName("dns_settings")]
    [Optional]
    public VirtualMachineResourceVirtualMachinePublicIPAddressDnsSettingsConfigurationSchema DnsSettings { get; set; }


    [HclName("ip_tag")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineIPTagSchema> IPTag { get; set; }


    [HclName("idle_timeout_in_minutes")]
    [Optional]
    public int IdleTimeoutInMinutes { get; set; }


    [HclName("public_ip_address_version")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.IPVersionsConstant))]
    public string PublicIPAddressVersion { get; set; }


    [HclName("public_ip_allocation_method")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.PublicIPAllocationMethodConstant))]
    public string PublicIPAllocationMethod { get; set; }


    [HclName("public_ip_prefix")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema PublicIPPrefix { get; set; }

}
