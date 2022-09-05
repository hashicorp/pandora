using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceApplicationProfileSchema
{

    [HclName("gallery_application")]
    [Optional]
    public List<List<VirtualMachineScaleSetResourceVMGalleryApplicationSchema>> GalleryApplication { get; set; }

}
