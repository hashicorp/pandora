using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.Resources.v2020_06_01.ResourceGroups;

namespace Pandora.Definitions.ResourceManager.Resources.Terraform;

public class ResourceGroupResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Name).ToSdkModelField<ResourceGroupModel>(m => m.Name),
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Location).ToSdkModelField<ResourceGroupModel>(m => m.Location),
        Mapping.FromSchema<ResourceGroupResourceSchema>(s => s.Tags).ToSdkModelField<ResourceGroupModel>(m => m.Tags),
    };
}