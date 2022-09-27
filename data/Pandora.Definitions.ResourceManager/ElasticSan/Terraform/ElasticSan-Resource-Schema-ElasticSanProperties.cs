using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.ElasticSan.Terraform;

public class ElasticSanResourceElasticSanPropertiesSchema
{

    [HclName("base_size_tib")]
    [Required]
    public int BaseSizeTiB { get; set; }


    [HclName("extended_capacity_size_tib")]
    [Required]
    public int ExtendedCapacitySizeTiB { get; set; }


    [Computed]
    [HclName("provisioning_state")]
    [PossibleValuesFromConstant(typeof(v2021_11_20_preview.ElasticSans.ProvisioningStatesConstant))]
    public string ProvisioningState { get; set; }


    [HclName("sku")]
    [Required]
    public ElasticSanResourceSkuSchema Sku { get; set; }


    [Computed]
    [HclName("total_iops")]
    public int TotalIops { get; set; }


    [Computed]
    [HclName("total_mbps")]
    public int TotalMBps { get; set; }


    [Computed]
    [HclName("total_size_tib")]
    public int TotalSizeTiB { get; set; }


    [Computed]
    [HclName("total_volume_size_gib")]
    public int TotalVolumeSizeGiB { get; set; }


    [Computed]
    [HclName("volume_group_count")]
    public int VolumeGroupCount { get; set; }


    [HclName("zones")]
    [Optional]
    public List<string> Zones { get; set; }

}
