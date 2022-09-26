using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceSchema
{

    [Documentation("The Azure Region where the resource should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("Specifies the name of this Resource Group.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public CommonSchema.ResourceGroupName Name { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Resource.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
