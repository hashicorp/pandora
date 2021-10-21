using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{

    internal abstract class TokenKeyModel
    {
        [JsonPropertyName("kid")]
        [Required]
        public string Kid { get; set; }

        [JsonPropertyName("@type")]
        [ProvidesTypeHint]
        [Required]
        public string Type { get; set; }
    }
}
