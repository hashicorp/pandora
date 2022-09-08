using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceApplicationProfileSchema
{

    [HclName("gallery_application")]
    [Optional]
    public List<VirtualMachineResourceVMGalleryApplicationSchema> GalleryApplication { get; set; }

}
