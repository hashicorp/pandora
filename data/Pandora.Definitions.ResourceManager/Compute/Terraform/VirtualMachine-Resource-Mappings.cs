using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        // Mapping.FromSchema<VirtualMachineResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<VirtualMachineResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<VirtualMachineResourceSchema>(s => s.Location).ToSdkModelField<VirtualMachineModel>(m => m.Location),
        // Mapping.FromSchema<VirtualMachineResourceSchema>(s => s.Tags).ToSdkModelField<VirtualMachineModel>(m => m.Tags),
        // Mapping.FromSchema<VirtualMachineResourceSchema>(s => s.UniqueId).ToSdkModelField<VirtualMachineModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<VirtualMachineResourceSchema>(s => s.DataDisks).ToSdkModel<VirtualMachineDataDiskModel>(),
        // Mapping.FromSchema<VirtualMachineDataDiskSchemaModel>(s => s.Name).ToSdkModelField<VirtualMachineDataDiskModel>(m => m.Name),
    };
}
