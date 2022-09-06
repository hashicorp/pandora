using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSshConfigurationSchema
{

    [HclName("public_key")]
    [Optional]
    public List<VirtualMachineScaleSetResourceSshPublicKeySchema> PublicKey { get; set; }

}
