using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.WebApplicationFirewallPolicies;


internal class PrivateEndpointConnectionPropertiesModel
{
    [JsonPropertyName("linkIdentifier")]
    public string? LinkIdentifier { get; set; }

    [JsonPropertyName("privateEndpoint")]
    public PrivateEndpointModel? PrivateEndpoint { get; set; }

    [JsonPropertyName("privateEndpointLocation")]
    public string? PrivateEndpointLocation { get; set; }

    [JsonPropertyName("privateLinkServiceConnectionState")]
    public PrivateLinkServiceConnectionStateModel? PrivateLinkServiceConnectionState { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
