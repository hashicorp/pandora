using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceResourceGroupPropertiesSchema
{

    [HclName("provisioning_state")]
    public string ProvisioningState { get; set; }

}
