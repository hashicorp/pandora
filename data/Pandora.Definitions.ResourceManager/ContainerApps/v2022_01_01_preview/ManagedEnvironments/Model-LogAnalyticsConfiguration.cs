using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;


internal class LogAnalyticsConfigurationModel
{
    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("sharedKey")]
    public string? SharedKey { get; set; }
}
