using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class GatewayLoadBalancerTunnelInterfaceModel
{
    [JsonPropertyName("identifier")]
    public int? Identifier { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("protocol")]
    public GatewayLoadBalancerTunnelProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("type")]
    public GatewayLoadBalancerTunnelInterfaceTypeConstant? Type { get; set; }
}
