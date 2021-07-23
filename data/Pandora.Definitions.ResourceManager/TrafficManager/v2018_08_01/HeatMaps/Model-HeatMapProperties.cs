using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps
{

    internal class HeatMapProperties
    {
        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonPropertyName("endpoints")]
        public List<HeatMapEndpoint>? Endpoints { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonPropertyName("trafficFlows")]
        public List<TrafficFlow>? TrafficFlows { get; set; }
    }
}
