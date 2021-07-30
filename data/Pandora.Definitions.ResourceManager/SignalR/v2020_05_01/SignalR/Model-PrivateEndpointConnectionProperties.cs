using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{

    internal class PrivateEndpointConnectionProperties
    {
        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpoint? PrivateEndpoint { get; set; }

        [JsonPropertyName("privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionState? PrivateLinkServiceConnectionState { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningState? ProvisioningState { get; set; }
    }
}
