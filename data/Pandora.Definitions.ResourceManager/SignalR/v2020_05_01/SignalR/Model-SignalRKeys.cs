using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class SignalRKeysModel
    {
        [JsonPropertyName("primaryConnectionString")]
        public string? PrimaryConnectionString { get; set; }

        [JsonPropertyName("primaryKey")]
        public string? PrimaryKey { get; set; }

        [JsonPropertyName("secondaryConnectionString")]
        public string? SecondaryConnectionString { get; set; }

        [JsonPropertyName("secondaryKey")]
        public string? SecondaryKey { get; set; }
    }
}
