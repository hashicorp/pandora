using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;


internal class AppLogsConfigurationModel
{
    [JsonPropertyName("destination")]
    public string? Destination { get; set; }

    [JsonPropertyName("logAnalyticsConfiguration")]
    public LogAnalyticsConfigurationModel? LogAnalyticsConfiguration { get; set; }
}
