using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class SignalRUsage
    {
        [JsonPropertyName("currentValue")]
        public int? CurrentValue { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("name")]
        public SignalRUsageName? Name { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }
    }
}
