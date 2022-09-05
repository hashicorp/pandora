using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceVMGalleryApplicationSchema
{

    [HclName("configuration_reference")]
    [Optional]
    public string ConfigurationReference { get; set; }


    [HclName("order")]
    [Optional]
    public int Order { get; set; }


    [HclName("package_reference_id")]
    [Required]
    public string PackageReferenceId { get; set; }


    [HclName("tags")]
    [Optional]
    public string Tags { get; set; }

}
