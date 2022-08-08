using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceSchema
{
    [HclName("name")]
    [ForceNew]
    [Required]
    public string Name { get; set; }
    
    [HclName("name")]
    [ForceNew]
    [Required]
    public CustomTypes.Location Location { get; set; }
    
    [HclName("name")]
    [Optional]
    public CustomTypes.Tags Tags { get; set; }
}
