using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.LoadTestService.Terraform;

public class LoadTestResourceSchema
{

    [Computed]
    [Documentation("Resource data plane URI.")]
    [HclName("data_plane_uri")]
    public string DataPlaneURI { get; set; }


    [Documentation("Description of the resource.")]
    [ForceNew]
    [HclName("description")]
    [Optional]
    public string Description { get; set; }


    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAssignedIdentity Identity { get; set; }


    [Documentation("The Azure Region where the Load Test should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("Specifies the name of this Load Test.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this Load Test should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Load Test.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
