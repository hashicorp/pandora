using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineExtensionSchema
{

    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [HclName("name")]
    [Optional]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public List<VirtualMachineResourceVirtualMachineExtensionPropertiesSchema> Properties { get; set; }


    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [HclName("type")]
    [Optional]
    public string Type { get; set; }

}
