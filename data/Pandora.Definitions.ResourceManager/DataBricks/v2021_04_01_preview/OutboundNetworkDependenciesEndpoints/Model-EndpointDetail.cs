using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.OutboundNetworkDependenciesEndpoints
{

    internal class EndpointDetailModel
    {
        [JsonPropertyName("ipAddress")]
        public string? IpAddress { get; set; }

        [JsonPropertyName("isAccessible")]
        public bool? IsAccessible { get; set; }

        [JsonPropertyName("latency")]
        public float? Latency { get; set; }

        [JsonPropertyName("port")]
        public int? Port { get; set; }
    }
}
