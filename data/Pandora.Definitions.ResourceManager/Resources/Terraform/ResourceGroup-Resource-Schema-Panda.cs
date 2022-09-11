using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourcePandaSchema
{
    [HclName("name")]
    [Optional]
    public string Name { get; set; }
}
