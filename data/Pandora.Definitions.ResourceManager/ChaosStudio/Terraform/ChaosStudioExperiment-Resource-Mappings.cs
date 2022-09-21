using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Location).ToSdkModelField<ChaosStudioExperimentModel>(m => m.Location),
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.Tags).ToSdkModelField<ChaosStudioExperimentModel>(m => m.Tags),
        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.UniqueId).ToSdkModelField<ChaosStudioExperimentModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<ChaosStudioExperimentResourceSchema>(s => s.DataDisks).ToSdkModel<ChaosStudioExperimentDataDiskModel>(),
        // Mapping.FromSchema<ChaosStudioExperimentDataDiskSchemaModel>(s => s.Name).ToSdkModelField<ChaosStudioExperimentDataDiskModel>(m => m.Name),
    };
}
