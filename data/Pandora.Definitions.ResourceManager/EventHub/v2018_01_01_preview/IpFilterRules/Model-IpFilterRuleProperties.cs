using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.IpFilterRules;


internal class IpFilterRulePropertiesModel
{
    [JsonPropertyName("action")]
    public IPActionConstant? Action { get; set; }

    [JsonPropertyName("filterName")]
    public string? FilterName { get; set; }

    [JsonPropertyName("ipMask")]
    public string? IpMask { get; set; }
}
