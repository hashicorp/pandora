using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceSchema
{

    [HclName("identity")]
    [Optional]
    public CommonSchema.SystemAssignedIdentity Identity { get; set; }


    [Documentation("The Azure Region where the resource should exist.")]
    [ForceNew]
    [HclName("location")]
    [Required]
    public CommonSchema.Location Location { get; set; }


    [Documentation("Specifies the name of this Chaos Studio Experiment.")]
    [ForceNew]
    [HclName("name")]
    [Required]
    public string Name { get; set; }


    [Documentation("Specifies the name of the Resource Group within which this Chaos Studio Experiment should exist.")]
    [ForceNew]
    [HclName("resource_group_name")]
    [Required]
    public CommonSchema.ResourceGroupName ResourceGroupName { get; set; }


    [Documentation("List of selectors.")]
    [ForceNew]
    [HclName("selector")]
    [Required]
    public List<ChaosStudioExperimentResourceSelectorSchema> Selector { get; set; }


    [Documentation("A boolean value that indicates if experiment should be started on creation or not.")]
    [ForceNew]
    [HclName("start_on_creation")]
    [Optional]
    public bool StartOnCreation { get; set; }


    [Documentation("List of steps.")]
    [ForceNew]
    [HclName("step")]
    [Required]
    public List<ChaosStudioExperimentResourceStepSchema> Step { get; set; }


    [Documentation("A mapping of tags which should be assigned to the Resource.")]
    [HclName("tags")]
    [Optional]
    public CommonSchema.Tags Tags { get; set; }

}
