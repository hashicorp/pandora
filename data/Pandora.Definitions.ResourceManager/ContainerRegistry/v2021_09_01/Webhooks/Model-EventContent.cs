using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;


internal class EventContentModel
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("actor")]
    public ActorModel? Actor { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("request")]
    public RequestModel? Request { get; set; }

    [JsonPropertyName("source")]
    public SourceModel? Source { get; set; }

    [JsonPropertyName("target")]
    public TargetModel? Target { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }
}
