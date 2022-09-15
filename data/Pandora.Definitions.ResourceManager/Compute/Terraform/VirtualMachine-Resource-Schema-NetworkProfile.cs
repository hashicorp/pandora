using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceNetworkProfileSchema
{

    [HclName("network_api_version")]
    [Optional]
    public string NetworkApiVersion { get; set; }


    [HclName("network_interface")]
    [Optional]
    public List<VirtualMachineResourceNetworkInterfaceReferenceSchema> NetworkInterface { get; set; }


    [HclName("network_interface_configuration")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineNetworkInterfaceConfigurationSchema> NetworkInterfaceConfiguration { get; set; }

}
