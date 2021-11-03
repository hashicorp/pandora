using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class MetricNameModel
    {
        [JsonPropertyName("localizedValue")]
        public string? LocalizedValue { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
