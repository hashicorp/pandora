using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.Skus;


internal class RestrictionModel
{
    [JsonPropertyName("reasonCode")]
    public ReasonCodeConstant? ReasonCode { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("values")]
    public List<string>? Values { get; set; }
}
