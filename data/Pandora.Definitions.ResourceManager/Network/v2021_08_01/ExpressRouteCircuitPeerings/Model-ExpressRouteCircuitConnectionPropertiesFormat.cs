using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRouteCircuitPeerings;


internal class ExpressRouteCircuitConnectionPropertiesFormatModel
{
    [JsonPropertyName("addressPrefix")]
    public string? AddressPrefix { get; set; }

    [JsonPropertyName("authorizationKey")]
    public string? AuthorizationKey { get; set; }

    [JsonPropertyName("circuitConnectionStatus")]
    public CircuitConnectionStatusConstant? CircuitConnectionStatus { get; set; }

    [JsonPropertyName("expressRouteCircuitPeering")]
    public SubResourceModel? ExpressRouteCircuitPeering { get; set; }

    [JsonPropertyName("ipv6CircuitConnectionConfig")]
    public IPv6CircuitConnectionConfigModel? IPv6CircuitConnectionConfig { get; set; }

    [JsonPropertyName("peerExpressRouteCircuitPeering")]
    public SubResourceModel? PeerExpressRouteCircuitPeering { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
