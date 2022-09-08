using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineNetworkInterfaceDnsSettingsConfigurationSchema
{

    [HclName("dns_server")]
    [Optional]
    public List<string> DnsServer { get; set; }

}
