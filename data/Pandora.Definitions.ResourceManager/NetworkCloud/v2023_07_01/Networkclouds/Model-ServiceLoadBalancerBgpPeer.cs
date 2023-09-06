using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ServiceLoadBalancerBgpPeerModel
{
    [JsonPropertyName("bfdEnabled")]
    public BfdEnabledConstant? BfdEnabled { get; set; }

    [JsonPropertyName("bgpMultiHop")]
    public BgpMultiHopConstant? BgpMultiHop { get; set; }

    [JsonPropertyName("holdTime")]
    public string? HoldTime { get; set; }

    [JsonPropertyName("keepAliveTime")]
    public string? KeepAliveTime { get; set; }

    [JsonPropertyName("myAsn")]
    public int? MyAsn { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("peerAddress")]
    [Required]
    public string PeerAddress { get; set; }

    [JsonPropertyName("peerAsn")]
    [Required]
    public int PeerAsn { get; set; }

    [JsonPropertyName("peerPort")]
    public int? PeerPort { get; set; }
}
