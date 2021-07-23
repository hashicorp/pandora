using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Endpoints
{

    internal class EndpointProperties
    {
        [JsonPropertyName("customHeaders")]
        public List<EndpointPropertiesCustomHeaders>? CustomHeaders { get; set; }

        [JsonPropertyName("endpointLocation")]
        public string? EndpointLocation { get; set; }

        [JsonPropertyName("endpointMonitorStatus")]
        public EndpointMonitorStatus? EndpointMonitorStatus { get; set; }

        [JsonPropertyName("endpointStatus")]
        public EndpointStatus? EndpointStatus { get; set; }

        [JsonPropertyName("geoMapping")]
        public List<string>? GeoMapping { get; set; }

        [JsonPropertyName("minChildEndpoints")]
        public int? MinChildEndpoints { get; set; }

        [JsonPropertyName("minChildEndpointsIPv4")]
        public int? MinChildEndpointsIPv4 { get; set; }

        [JsonPropertyName("minChildEndpointsIPv6")]
        public int? MinChildEndpointsIPv6 { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("subnets")]
        public List<EndpointPropertiesSubnets>? Subnets { get; set; }

        [JsonPropertyName("target")]
        public string? Target { get; set; }

        [JsonPropertyName("targetResourceId")]
        public string? TargetResourceId { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }
    }
}
