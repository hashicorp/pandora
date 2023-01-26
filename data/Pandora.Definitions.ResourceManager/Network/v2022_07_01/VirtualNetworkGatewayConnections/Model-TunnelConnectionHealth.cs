using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGatewayConnections;


internal class TunnelConnectionHealthModel
{
    [JsonPropertyName("connectionStatus")]
    public VirtualNetworkGatewayConnectionStatusConstant? ConnectionStatus { get; set; }

    [JsonPropertyName("egressBytesTransferred")]
    public int? EgressBytesTransferred { get; set; }

    [JsonPropertyName("ingressBytesTransferred")]
    public int? IngressBytesTransferred { get; set; }

    [JsonPropertyName("lastConnectionEstablishedUtcTime")]
    public string? LastConnectionEstablishedUtcTime { get; set; }

    [JsonPropertyName("tunnel")]
    public string? Tunnel { get; set; }
}
