using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGateways;


internal class VpnClientConnectionHealthDetailModel
{
    [JsonPropertyName("egressBytesTransferred")]
    public int? EgressBytesTransferred { get; set; }

    [JsonPropertyName("egressPacketsTransferred")]
    public int? EgressPacketsTransferred { get; set; }

    [JsonPropertyName("ingressBytesTransferred")]
    public int? IngressBytesTransferred { get; set; }

    [JsonPropertyName("ingressPacketsTransferred")]
    public int? IngressPacketsTransferred { get; set; }

    [JsonPropertyName("maxBandwidth")]
    public int? MaxBandwidth { get; set; }

    [JsonPropertyName("maxPacketsPerSecond")]
    public int? MaxPacketsPerSecond { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIPAddress { get; set; }

    [JsonPropertyName("vpnConnectionDuration")]
    public int? VpnConnectionDuration { get; set; }

    [JsonPropertyName("vpnConnectionId")]
    public string? VpnConnectionId { get; set; }

    [JsonPropertyName("vpnConnectionTime")]
    public string? VpnConnectionTime { get; set; }

    [JsonPropertyName("vpnUserName")]
    public string? VpnUserName { get; set; }
}
