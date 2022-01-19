using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

internal class SkuModel
{
    [JsonPropertyName("name")]
    [Required]
    public SkuName Name { get; set; }

    [JsonPropertyName("tier")]
    [Required]
    public SkuTier Tier { get; set; }
}