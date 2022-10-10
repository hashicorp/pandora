using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Location).ToSdkField<ResourceGroupModel>(m => m.Location),
        // Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Tags).ToSdkField<ResourceGroupModel>(m => m.Tags),
        // Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.UniqueId).ToSdkField<ResourceGroupModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.DataDisks).ToSdkModel<ResourceGroupDataDiskModel>(),
        // Mapping.FromSchema<ResourceGroupDataDiskSchemaModel>(s => s.Name).ToSdkField<ResourceGroupDataDiskModel>(m => m.Name),
    };
}
