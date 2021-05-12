using System.ComponentModel;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.Namespace
{
    internal class Sku
    {
        [JsonPropertyName("capacity")]
        [Optional]
        public int Capacity { get; set; }
            
        [JsonPropertyName("name")]
        [Required]
        [ForceNew]
        public SkuTier Name { get; set; }
            
        [JsonPropertyName("tier")]
        [Required]
        [ForceNew]
        public SkuTier Tier { get; set; }
    }

    internal enum SkuTier
    {
        [Description("Basic")]
        Basic,
            
        [Description("Standard")]
        Standard
    }
}