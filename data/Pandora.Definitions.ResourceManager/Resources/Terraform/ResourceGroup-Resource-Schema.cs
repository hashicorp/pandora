using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceSchema
{

    [HclName("location")]
    [ForceNew]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [HclName("name")]
    [ForceNew]
    [Required]
    public string Name { get; set; }


    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
