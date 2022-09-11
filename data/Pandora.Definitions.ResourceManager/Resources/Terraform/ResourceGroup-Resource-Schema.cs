using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceSchema
{

    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }
    
    [HclName("direct_assignment_field")]
    [Optional]
    public string DirectAssignmentField { get; set; }
    
    [HclName("pandas")]
    [Optional]
    public List<ResourceGroupResourcePandaSchema> Pandas { get; set; }

    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
