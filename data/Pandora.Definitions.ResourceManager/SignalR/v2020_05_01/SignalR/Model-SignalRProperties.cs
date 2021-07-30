using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class SignalRProperties
    {
        [JsonPropertyName("cors")]
        public SignalRCorsSettings? Cors { get; set; }

        [JsonPropertyName("externalIP")]
        public string? ExternalIP { get; set; }

        [JsonPropertyName("features")]
        public List<SignalRFeature>? Features { get; set; }

        [JsonPropertyName("hostName")]
        public string? HostName { get; set; }

        [JsonPropertyName("hostNamePrefix")]
        public string? HostNamePrefix { get; set; }

        [JsonPropertyName("networkACLs")]
        public SignalRNetworkACLs? NetworkACLs { get; set; }

        [JsonPropertyName("privateEndpointConnections")]
        public List<PrivateEndpointConnection>? PrivateEndpointConnections { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningState? ProvisioningState { get; set; }

        [JsonPropertyName("publicPort")]
        public int? PublicPort { get; set; }

        [JsonPropertyName("serverPort")]
        public int? ServerPort { get; set; }

        [JsonPropertyName("upstream")]
        public ServerlessUpstreamSettings? Upstream { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }
    }
}
