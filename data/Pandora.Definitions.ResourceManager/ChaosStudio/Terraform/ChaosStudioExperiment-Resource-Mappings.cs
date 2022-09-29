using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.Experiments;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("experimentName"),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<ChaosStudioExperimentResourceActionSchema>(s => s.Name).ToSdkField<ActionModel>(m => m.Name).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceActionSchema>(s => s.Type).ToSdkField<ActionModel>(m => m.Type).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceBranchSchema>(s => s.Action).ToSdkField<BranchModel>(m => m.Actions).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceBranchSchema>(s => s.Name).ToSdkField<BranchModel>(m => m.Name).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Identity).ToSdkField<ExperimentModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Location).ToSdkField<ExperimentModel>(m => m.Location).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Selector).ToSdkField<ExperimentPropertiesModel>(m => m.Selectors).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.StartOnCreation).ToSdkField<ExperimentPropertiesModel>(m => m.StartOnCreation).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Step).ToSdkField<ExperimentPropertiesModel>(m => m.Steps).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Tags).ToSdkField<ExperimentModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSelectorSchema>(s => s.Id).ToSdkField<SelectorModel>(m => m.Id).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSelectorSchema>(s => s.Target).ToSdkField<SelectorModel>(m => m.Targets).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSelectorSchema>(s => s.Type).ToSdkField<SelectorModel>(m => m.Type).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceStepSchema>(s => s.Branch).ToSdkField<StepModel>(m => m.Branches).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceStepSchema>(s => s.Name).ToSdkField<StepModel>(m => m.Name).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceTargetReferenceSchema>(s => s.Id).ToSdkField<TargetReferenceModel>(m => m.Id).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceTargetReferenceSchema>(s => s.Type).ToSdkField<TargetReferenceModel>(m => m.Type).Direct(),
    };
}
