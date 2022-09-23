using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.ElasticSan.Terraform;

public class ElasticSanResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Location).ToSdkField<ElasticSanModel>(m => m.Location),
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Tags).ToSdkField<ElasticSanModel>(m => m.Tags),
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.UniqueId).ToSdkField<ElasticSanModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.DataDisks).ToSdkModel<ElasticSanDataDiskModel>(),
        // Mapping.FromSchema<ElasticSanDataDiskSchemaModel>(s => s.Name).ToSdkField<ElasticSanDataDiskModel>(m => m.Name),
    };
}
