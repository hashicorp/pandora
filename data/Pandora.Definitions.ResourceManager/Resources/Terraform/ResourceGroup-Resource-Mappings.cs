using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Location).ToSdkModelField<ResourceGroupResourceSchema>(m => m.Location),
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Tags).ToSdkModelField<ResourceGroupResourceSchema>(m => m.Tags),
        // Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.UniqueId).ToSdkModelField<ResourceGroupResourceSchema>(m => m.Properties.UniqueId),
        //
        // Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.DataDisks).ToSdkModel<ResourceGroupDataDiskModel>(),
        // Mapping.FromSchema<ResourceGroupDataDiskSchemaModel>(s => s.Name).ToSdkModelField<ResourceGroupDataDiskModel>(m => m.Name),
    };
}
