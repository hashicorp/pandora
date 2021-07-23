using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{

    internal class MonitorConfigExpectedStatusCodeRanges
    {
        [JsonPropertyName("max")]
        public int? Max { get; set; }

        [JsonPropertyName("min")]
        public int? Min { get; set; }
    }
}
