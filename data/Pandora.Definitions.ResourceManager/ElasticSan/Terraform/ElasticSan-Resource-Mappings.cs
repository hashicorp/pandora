using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.ElasticSans;

namespace Pandora.Definitions.ResourceManager.ElasticSan.Terraform;

public class ElasticSanResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("elasticSanName"),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.BaseSizeTiB).ToSdkField<ElasticSanPropertiesModel>(m => m.BaseSizeTiB).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.BaseSizeTiB).ToSdkField<ElasticSanUpdatePropertiesModel>(m => m.BaseSizeTiB).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.ExtendedCapacitySizeTiB).ToSdkField<ElasticSanPropertiesModel>(m => m.ExtendedCapacitySizeTiB).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.ExtendedCapacitySizeTiB).ToSdkField<ElasticSanUpdatePropertiesModel>(m => m.ExtendedCapacitySizeTiB).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Location).ToSdkField<ElasticSanModel>(m => m.Location).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Sku).ToSdkField<ElasticSanPropertiesModel>(m => m.Sku).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Tags).ToSdkField<ElasticSanModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Tags).ToSdkField<ElasticSanUpdateModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.TotalIops).ToSdkField<ElasticSanPropertiesModel>(m => m.TotalIops).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.TotalMBps).ToSdkField<ElasticSanPropertiesModel>(m => m.TotalMBps).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.TotalSizeTiB).ToSdkField<ElasticSanPropertiesModel>(m => m.TotalSizeTiB).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.TotalVolumeSizeGiB).ToSdkField<ElasticSanPropertiesModel>(m => m.TotalVolumeSizeGiB).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.VolumeGroupCount).ToSdkField<ElasticSanPropertiesModel>(m => m.VolumeGroupCount).Direct(),
        Mapping.FromSchema<ElasticSanResourceSchema>(s => s.Zones).ToSdkField<ElasticSanPropertiesModel>(m => m.AvailabilityZones).Direct(),
    };
}
