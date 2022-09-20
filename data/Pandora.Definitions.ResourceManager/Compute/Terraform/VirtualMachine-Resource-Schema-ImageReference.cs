using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceImageReferenceSchema
{

    [HclName("community_gallery_image_id")]
    [Optional]
    public string CommunityGalleryImageId { get; set; }


    [Computed]
    [HclName("exact_version")]
    public string ExactVersion { get; set; }


    [HclName("id")]
    [Optional]
    public string Id { get; set; }


    [HclName("offer")]
    [Optional]
    public string Offer { get; set; }


    [HclName("publisher")]
    [Optional]
    public string Publisher { get; set; }


    [HclName("shared_gallery_image_id")]
    [Optional]
    public string SharedGalleryImageId { get; set; }


    [HclName("sku")]
    [Optional]
    public string Sku { get; set; }


    [HclName("version")]
    [Optional]
    public string Version { get; set; }

}
