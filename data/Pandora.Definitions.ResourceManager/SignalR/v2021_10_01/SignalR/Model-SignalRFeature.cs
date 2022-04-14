using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;


internal class SignalRFeatureModel
{
    [JsonPropertyName("flag")]
    [Required]
    public FeatureFlagsConstant Flag { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
