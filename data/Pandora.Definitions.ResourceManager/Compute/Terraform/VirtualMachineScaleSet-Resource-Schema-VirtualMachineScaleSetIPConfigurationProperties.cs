using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceVirtualMachineScaleSetIPConfigurationPropertiesSchema
{

    [HclName("application_gateway_backend_address_pool")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceSubResourceSchema>> ApplicationGatewayBackendAddressPool { get; set; }


    [HclName("application_security_group")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceSubResourceSchema>> ApplicationSecurityGroup { get; set; }


    [HclName("load_balancer_backend_address_pool")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceSubResourceSchema>> LoadBalancerBackendAddressPool { get; set; }


    [HclName("load_balancer_inbound_nat_pool")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceSubResourceSchema>> LoadBalancerInboundNatPool { get; set; }


    [HclName("primary")]
    [Optional]
    public bool Primary { get; set; }


    [HclName("private_ip_address_version")]
    [Optional]
    public string PrivateIPAddressVersion { get; set; }


    [HclName("public_ip_address_configuration")]
    [Optional]
    public List<VirtualMachineScaleSetResourceVirtualMachineScaleSetPublicIPAddressConfigurationSchema> PublicIPAddressConfiguration { get; set; }


    [HclName("subnet_id")]
    [Optional]
    public List<VirtualMachineScaleSetResourceApiEntityReferenceSchema> SubnetId { get; set; }

}
