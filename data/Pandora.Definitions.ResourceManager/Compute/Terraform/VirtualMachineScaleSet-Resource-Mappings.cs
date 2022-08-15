using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        // Mapping.FromSchema<VirtualMachineScaleSetResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<VirtualMachineScaleSetResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<VirtualMachineScaleSetResourceSchema>(s => s.Location).ToSdkModelField<VirtualMachineScaleSetModel>(m => m.Location),
        // Mapping.FromSchema<VirtualMachineScaleSetResourceSchema>(s => s.Tags).ToSdkModelField<VirtualMachineScaleSetModel>(m => m.Tags),
        // Mapping.FromSchema<VirtualMachineScaleSetResourceSchema>(s => s.UniqueId).ToSdkModelField<VirtualMachineScaleSetModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<VirtualMachineScaleSetResourceSchema>(s => s.DataDisks).ToSdkModel<VirtualMachineScaleSetDataDiskModel>(),
        // Mapping.FromSchema<VirtualMachineScaleSetDataDiskSchemaModel>(s => s.Name).ToSdkModelField<VirtualMachineScaleSetDataDiskModel>(m => m.Name),
    };
}
