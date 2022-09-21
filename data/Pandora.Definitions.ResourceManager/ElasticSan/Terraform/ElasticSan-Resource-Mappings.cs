using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace Pandora.Definitions.ResourceManager.ElasticSan.Terraform;

public class ElasticSanResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Location).ToSdkModelField<ElasticSanModel>(m => m.Location),
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Tags).ToSdkModelField<ElasticSanModel>(m => m.Tags),
        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.UniqueId).ToSdkModelField<ElasticSanModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<ElasticSanResourceSchema>(s => s.DataDisks).ToSdkModel<ElasticSanDataDiskModel>(),
        // Mapping.FromSchema<ElasticSanDataDiskSchemaModel>(s => s.Name).ToSdkModelField<ElasticSanDataDiskModel>(m => m.Name),
    };
}
