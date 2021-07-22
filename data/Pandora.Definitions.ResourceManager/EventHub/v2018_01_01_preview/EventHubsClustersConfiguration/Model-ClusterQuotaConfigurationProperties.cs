using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersConfiguration
{

    internal class ClusterQuotaConfigurationProperties
    {
        [JsonPropertyName("settings")]
        public string? Settings { get; set; }
    }
}
