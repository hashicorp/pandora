using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;


internal class MonitorConfigModel
{
    [JsonPropertyName("customHeaders")]
    public List<MonitorConfigCustomHeadersInlinedModel>? CustomHeaders { get; set; }

    [JsonPropertyName("expectedStatusCodeRanges")]
    public List<MonitorConfigExpectedStatusCodeRangesInlinedModel>? ExpectedStatusCodeRanges { get; set; }

    [JsonPropertyName("intervalInSeconds")]
    public int? IntervalInSeconds { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("profileMonitorStatus")]
    public ProfileMonitorStatusConstant? ProfileMonitorStatus { get; set; }

    [JsonPropertyName("protocol")]
    public MonitorProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("timeoutInSeconds")]
    public int? TimeoutInSeconds { get; set; }

    [JsonPropertyName("toleratedNumberOfFailures")]
    public int? ToleratedNumberOfFailures { get; set; }
}
