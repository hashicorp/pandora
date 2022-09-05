using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceSshConfigurationSchema
{

    [HclName("public_key")]
    [Optional]
    public List<List<VirtualMachineResourceSshPublicKeySchema>> PublicKey { get; set; }

}
