using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterProjectResourceSchema
{

    [Documentation("Description of the project.")]
    [ForceNew]
    [HclName("description")]
    [Optional]
    public string Description { get; set; }


    [Documentation("Resource Id of an associated DevCenter.")]
    [ForceNew]
    [HclName("dev_center_id")]
    [Required]
    public string DevCenterId { get; set; }


    [Computed]
    [Documentation("The URI of the Dev Center resource this project is associated with.")]
    [HclName("dev_center_uri")]
    public string DevCenterUri { get; set; }


    [Documentation("The Azure Region where the Dev Center Project should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("When specified, limits the maximum number of Dev Boxes a single user can create across all pools in the project.")]
    [HclName("max_dev_boxes_per_user")]
    [Optional]
    public int MaxDevBoxesPerUser { get; set; }


    [Documentation("Specifies the name of this Dev Center Project.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this Dev Center Project should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Dev Center Project.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
