using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;


internal class EventModel
{
    [JsonPropertyName("eventRequestMessage")]
    public EventRequestMessageModel? EventRequestMessage { get; set; }

    [JsonPropertyName("eventResponseMessage")]
    public EventResponseMessageModel? EventResponseMessage { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }
}
