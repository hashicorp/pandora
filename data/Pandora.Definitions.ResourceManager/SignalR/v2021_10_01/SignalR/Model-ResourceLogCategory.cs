using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;


internal class ResourceLogCategoryModel
{
    [JsonPropertyName("enabled")]
    public string? Enabled { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
