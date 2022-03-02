using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitoredResources;


internal class MonitoredResourceModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("reasonForLogsStatus")]
    public string? ReasonForLogsStatus { get; set; }

    [JsonPropertyName("sendingLogs")]
    public SendingLogsConstant? SendingLogs { get; set; }
}
