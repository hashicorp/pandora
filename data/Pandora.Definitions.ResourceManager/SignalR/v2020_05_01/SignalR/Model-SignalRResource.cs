using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class SignalRResource
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("kind")]
        public ServiceKind? Kind { get; set; }

        [JsonPropertyName("location")]
        public CustomTypes.Location? Location { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        public SignalRProperties? Properties { get; set; }

        [JsonPropertyName("sku")]
        public ResourceSku? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
