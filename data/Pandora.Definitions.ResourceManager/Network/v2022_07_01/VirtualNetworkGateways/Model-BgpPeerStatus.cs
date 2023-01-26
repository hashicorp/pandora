using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGateways;


internal class BgpPeerStatusModel
{
    [JsonPropertyName("asn")]
    public int? Asn { get; set; }

    [JsonPropertyName("connectedDuration")]
    public string? ConnectedDuration { get; set; }

    [JsonPropertyName("localAddress")]
    public string? LocalAddress { get; set; }

    [JsonPropertyName("messagesReceived")]
    public int? MessagesReceived { get; set; }

    [JsonPropertyName("messagesSent")]
    public int? MessagesSent { get; set; }

    [JsonPropertyName("neighbor")]
    public string? Neighbor { get; set; }

    [JsonPropertyName("routesReceived")]
    public int? RoutesReceived { get; set; }

    [JsonPropertyName("state")]
    public BgpPeerStateConstant? State { get; set; }
}
