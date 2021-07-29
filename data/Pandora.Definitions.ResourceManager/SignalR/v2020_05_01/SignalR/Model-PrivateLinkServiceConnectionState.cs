using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class PrivateLinkServiceConnectionState
    {
        [JsonPropertyName("actionsRequired")]
        public string? ActionsRequired { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        public PrivateLinkServiceConnectionStatus? Status { get; set; }
    }
}
