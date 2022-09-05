using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceResourceGroupPropertiesSchema
{

    [HclName("provisioning_state")]
    [Optional]
    public string ProvisioningState { get; set; }

}
