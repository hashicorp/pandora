using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{

    internal class MonitorConfig
    {
        [JsonPropertyName("customHeaders")]
        public List<MonitorConfigCustomHeaders>? CustomHeaders { get; set; }

        [JsonPropertyName("expectedStatusCodeRanges")]
        public List<MonitorConfigExpectedStatusCodeRanges>? ExpectedStatusCodeRanges { get; set; }

        [JsonPropertyName("intervalInSeconds")]
        public int? IntervalInSeconds { get; set; }

        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("port")]
        public int? Port { get; set; }

        [JsonPropertyName("profileMonitorStatus")]
        public ProfileMonitorStatus? ProfileMonitorStatus { get; set; }

        [JsonPropertyName("protocol")]
        public MonitorProtocol? Protocol { get; set; }

        [JsonPropertyName("timeoutInSeconds")]
        public int? TimeoutInSeconds { get; set; }

        [JsonPropertyName("toleratedNumberOfFailures")]
        public int? ToleratedNumberOfFailures { get; set; }
    }
}
