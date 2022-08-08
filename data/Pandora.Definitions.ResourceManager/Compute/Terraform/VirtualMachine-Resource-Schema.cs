using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceSchema
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