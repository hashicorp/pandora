using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.PrivateEndpointConnections;


internal class PrivateEndpointConnectionPropertiesModel
{
    [JsonPropertyName("privateEndpoint")]
    public PrivateEndpointModel? PrivateEndpoint { get; set; }

    [JsonPropertyName("privateLinkServiceConnectionState")]
    public PrivateLinkServiceConnectionStateModel? PrivateLinkServiceConnectionState { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
