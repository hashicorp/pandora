using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PrivateEndpointConnections
{

    internal class PrivateEndpointConnectionPropertiesModel
    {
        [JsonPropertyName("groupIds")]
        public List<string>? GroupIds { get; set; }

        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpointModel? PrivateEndpoint { get; set; }

        [JsonPropertyName("privateLinkServiceConnectionState")]
        public ConnectionStateModel? PrivateLinkServiceConnectionState { get; set; }

        [JsonPropertyName("provisioningState")]
        public ResourceProvisioningStateConstant? ProvisioningState { get; set; }
    }
}
