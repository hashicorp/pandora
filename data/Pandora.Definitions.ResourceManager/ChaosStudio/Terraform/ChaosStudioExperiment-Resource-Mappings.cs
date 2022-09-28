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

        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Identity).ToSdkField<ExperimentModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Location).ToSdkField<ExperimentModel>(m => m.Location).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Selector).ToSdkField<ExperimentPropertiesModel>(m => m.Selectors).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.StartOnCreation).ToSdkField<ExperimentPropertiesModel>(m => m.StartOnCreation).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Step).ToSdkField<ExperimentPropertiesModel>(m => m.Steps).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Tags).ToSdkField<ExperimentModel>(m => m.Tags).Direct(),

        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Identity).ToSdkField<ExperimentModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Selector).ToSdkField<ExperimentPropertiesModel>(m => m.Selectors).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.StartOnCreation).ToSdkField<ExperimentPropertiesModel>(m => m.StartOnCreation).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Step).ToSdkField<ExperimentPropertiesModel>(m => m.Steps).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Tags).ToSdkField<ExperimentModel>(m => m.Tags).Direct(),

        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Identity).ToSdkField<ExperimentModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Location).ToSdkField<ExperimentModel>(m => m.Location).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Selector).ToSdkField<ExperimentPropertiesModel>(m => m.Selectors).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.StartOnCreation).ToSdkField<ExperimentPropertiesModel>(m => m.StartOnCreation).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Step).ToSdkField<ExperimentPropertiesModel>(m => m.Steps).Direct(),
        Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Tags).ToSdkField<ExperimentModel>(m => m.Tags).Direct(),
    };
}
