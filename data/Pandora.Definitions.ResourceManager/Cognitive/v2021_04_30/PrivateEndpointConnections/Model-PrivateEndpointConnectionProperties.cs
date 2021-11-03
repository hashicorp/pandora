using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.PrivateEndpointConnections
{

    internal class PrivateEndpointConnectionPropertiesModel
    {
        [JsonPropertyName("groupIds")]
        public List<string>? GroupIds { get; set; }

        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpointModel? PrivateEndpoint { get; set; }

        [JsonPropertyName("privateLinkServiceConnectionState")]
        [Required]
        public PrivateLinkServiceConnectionStateModel PrivateLinkServiceConnectionState { get; set; }

        [JsonPropertyName("provisioningState")]
        public PrivateEndpointConnectionProvisioningStateConstant? ProvisioningState { get; set; }
    }
}
