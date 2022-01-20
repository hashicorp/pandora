using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections;


internal class PrivateEndpointConnectionPropertiesModel
{
    [JsonPropertyName("privateEndpoint")]
    public PrivateEndpointModel? PrivateEndpoint { get; set; }

    [JsonPropertyName("privateLinkServiceConnectionState")]
    public ConnectionStateModel? PrivateLinkServiceConnectionState { get; set; }

    [JsonPropertyName("provisioningState")]
    public EndPointProvisioningStateConstant? ProvisioningState { get; set; }
}
