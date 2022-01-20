using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.EventHubs;


internal class EventhubModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("properties")]
    public EventhubPropertiesModel? Properties { get; set; }

    [JsonPropertyName("systemData")]
    public SystemDataModel? SystemData { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
