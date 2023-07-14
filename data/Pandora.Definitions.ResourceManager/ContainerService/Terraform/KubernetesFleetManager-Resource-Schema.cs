using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesFleetManagerResourceSchema
{

    [Documentation("The FleetHubProfile configures the Fleet's hub.")]
    [ForceNew]
    [HclName("hub_profile")]
    [Optional]
    public KubernetesFleetManagerResourceFleetHubProfileSchema HubProfile { get; set; }


    [Documentation("The Azure Region where the Kubernetes Fleet Manager should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("Specifies the name of this Kubernetes Fleet Manager.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this Kubernetes Fleet Manager should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Kubernetes Fleet Manager.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
