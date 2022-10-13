using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.PrivateEndpointConnectionProxies;


internal class PrivateLinkServiceProxyModel
{
    [JsonPropertyName("groupConnectivityInformation")]
    public List<GroupConnectivityInformationModel>? GroupConnectivityInformation { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("remotePrivateEndpointConnection")]
    public RemotePrivateEndpointConnectionModel? RemotePrivateEndpointConnection { get; set; }

    [JsonPropertyName("remotePrivateLinkServiceConnectionState")]
    public PrivateLinkServiceConnectionStateModel? RemotePrivateLinkServiceConnectionState { get; set; }
}
