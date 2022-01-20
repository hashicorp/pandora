using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;

[ValueForType("#Microsoft.VideoAnalyzer.JwtAuthentication")]
internal class JwtAuthenticationModel : AuthenticationBaseModel
{
    [JsonPropertyName("audiences")]
    public List<string>? Audiences { get; set; }

    [JsonPropertyName("claims")]
    public List<TokenClaimModel>? Claims { get; set; }

    [JsonPropertyName("issuers")]
    public List<string>? Issuers { get; set; }

    [JsonPropertyName("keys")]
    public List<TokenKeyModel>? Keys { get; set; }
}
