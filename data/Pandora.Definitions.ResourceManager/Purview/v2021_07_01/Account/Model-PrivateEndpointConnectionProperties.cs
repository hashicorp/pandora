using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{

    internal class PrivateEndpointConnectionPropertiesModel
    {
        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpointModel? PrivateEndpoint { get; set; }

        [JsonPropertyName("privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionStateModel? PrivateLinkServiceConnectionState { get; set; }

        [JsonPropertyName("provisioningState")]
        public string? ProvisioningState { get; set; }
    }
}
