using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{

    internal class PrivateEndpointConnectionProperties
    {
        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpoint? PrivateEndpoint { get; set; }

        [JsonPropertyName("privateLinkServiceConnectionState")]
        public ConnectionState? PrivateLinkServiceConnectionState { get; set; }

        [JsonPropertyName("provisioningState")]
        public EndPointProvisioningState? ProvisioningState { get; set; }
    }
}
