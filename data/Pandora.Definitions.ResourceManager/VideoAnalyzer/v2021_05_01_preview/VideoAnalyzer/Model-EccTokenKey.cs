using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;

[ValueForType("#Microsoft.VideoAnalyzer.EccTokenKey")]
internal class EccTokenKeyModel : TokenKeyModel
{
    [JsonPropertyName("alg")]
    [Required]
    public AccessPolicyEccAlgoConstant Alg { get; set; }

    [JsonPropertyName("x")]
    [Required]
    public string X { get; set; }

    [JsonPropertyName("y")]
    [Required]
    public string Y { get; set; }
}
