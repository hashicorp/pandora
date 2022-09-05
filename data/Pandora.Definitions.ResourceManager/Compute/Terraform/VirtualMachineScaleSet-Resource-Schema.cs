using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceSchema
{
    // TODO: populate with a real schema

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
