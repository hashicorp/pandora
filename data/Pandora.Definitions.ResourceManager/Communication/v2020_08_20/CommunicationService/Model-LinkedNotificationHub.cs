using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService;


internal class LinkedNotificationHubModel
{
    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }
}
