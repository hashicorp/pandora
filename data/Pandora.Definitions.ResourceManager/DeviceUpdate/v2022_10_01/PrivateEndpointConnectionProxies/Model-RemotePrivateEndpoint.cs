using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.PrivateEndpointConnectionProxies;


internal class RemotePrivateEndpointModel
{
    [JsonPropertyName("connectionDetails")]
    public List<ConnectionDetailsModel>? ConnectionDetails { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("immutableResourceId")]
    public string? ImmutableResourceId { get; set; }

    [JsonPropertyName("immutableSubscriptionId")]
    public string? ImmutableSubscriptionId { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("manualPrivateLinkServiceConnections")]
    public List<PrivateLinkServiceConnectionModel>? ManualPrivateLinkServiceConnections { get; set; }

    [JsonPropertyName("privateLinkServiceConnections")]
    public List<PrivateLinkServiceConnectionModel>? PrivateLinkServiceConnections { get; set; }

    [JsonPropertyName("privateLinkServiceProxies")]
    public List<PrivateLinkServiceProxyModel>? PrivateLinkServiceProxies { get; set; }

    [JsonPropertyName("vnetTrafficTag")]
    public string? VnetTrafficTag { get; set; }
}
