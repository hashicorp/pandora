using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class StatusModel
{
    [JsonPropertyName("displayStatus")]
    public string? DisplayStatus { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }
}
