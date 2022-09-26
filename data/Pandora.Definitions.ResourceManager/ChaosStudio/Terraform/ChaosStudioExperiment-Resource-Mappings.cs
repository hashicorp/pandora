using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Location).ToSdkField<ChaosStudioExperimentModel>(m => m.Location),
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Tags).ToSdkField<ChaosStudioExperimentModel>(m => m.Tags),
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.UniqueId).ToSdkField<ChaosStudioExperimentModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.DataDisks).ToSdkModel<ChaosStudioExperimentDataDiskModel>(),
        // Mapping.FromSchema<ChaosStudioExperimentDataDiskSchemaModel>(s => s.Name).ToSdkField<ChaosStudioExperimentDataDiskModel>(m => m.Name),
    };
}
