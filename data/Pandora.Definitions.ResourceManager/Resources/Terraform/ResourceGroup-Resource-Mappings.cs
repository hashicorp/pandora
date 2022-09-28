using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.Resources.v2020_06_01.ResourceGroups;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Location).ToSdkField<ResourceGroupModel>(m => m.Location).Direct(),
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Tags).ToSdkField<ResourceGroupModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Tags).ToSdkField<ResourceGroupPatchableModel>(m => m.Tags).Direct(),
    };
}
