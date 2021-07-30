using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class SignalRUsageName
    {
        [JsonPropertyName("localizedValue")]
        public string? LocalizedValue { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
