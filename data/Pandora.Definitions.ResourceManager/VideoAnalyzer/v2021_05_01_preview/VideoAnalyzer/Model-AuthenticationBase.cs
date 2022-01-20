using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


internal abstract class AuthenticationBaseModel
{
    [JsonPropertyName("@type")]
    [ProvidesTypeHint]
    [Required]
    public string Type { get; set; }
}
