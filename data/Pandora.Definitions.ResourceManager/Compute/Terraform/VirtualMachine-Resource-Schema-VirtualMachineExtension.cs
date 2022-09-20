using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVirtualMachineExtensionSchema
{

    [Computed]
    [HclName("id")]
    public string Id { get; set; }


    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Computed]
    [HclName("name")]
    public string Name { get; set; }


    [HclName("properties")]
    [Optional]
    public VirtualMachineResourceVirtualMachineExtensionPropertiesSchema Properties { get; set; }


    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }


    [Computed]
    [HclName("type")]
    public string Type { get; set; }

}
