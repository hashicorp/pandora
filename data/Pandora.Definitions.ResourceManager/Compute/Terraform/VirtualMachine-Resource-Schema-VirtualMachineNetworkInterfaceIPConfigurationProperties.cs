using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineNetworkInterfaceIPConfigurationPropertiesSchema
{

    [HclName("application_gateway_backend_address_pool")]
    [Optional]
    public List<VirtualMachineResourceSubResourceSchema> ApplicationGatewayBackendAddressPool { get; set; }


    [HclName("application_security_group")]
    [Optional]
    public List<VirtualMachineResourceSubResourceSchema> ApplicationSecurityGroup { get; set; }


    [HclName("load_balancer_backend_address_pool")]
    [Optional]
    public List<VirtualMachineResourceSubResourceSchema> LoadBalancerBackendAddressPool { get; set; }


    [HclName("primary")]
    [Optional]
    public bool Primary { get; set; }


    [HclName("private_ip_address_version")]
    [Optional]
    public string PrivateIPAddressVersion { get; set; }


    [HclName("public_ip_address_configuration")]
    [Optional]
    public VirtualMachineResourceVirtualMachinePublicIPAddressConfigurationSchema PublicIPAddressConfiguration { get; set; }


    [HclName("subnet")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema Subnet { get; set; }

}
