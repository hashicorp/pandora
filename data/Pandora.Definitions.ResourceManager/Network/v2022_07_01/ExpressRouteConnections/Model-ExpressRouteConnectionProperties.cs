using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteConnections;


internal class ExpressRouteConnectionPropertiesModel
{
    [JsonPropertyName("authorizationKey")]
    public string? AuthorizationKey { get; set; }

    [JsonPropertyName("enableInternetSecurity")]
    public bool? EnableInternetSecurity { get; set; }

    [JsonPropertyName("enablePrivateLinkFastPath")]
    public bool? EnablePrivateLinkFastPath { get; set; }

    [JsonPropertyName("expressRouteCircuitPeering")]
    [Required]
    public ExpressRouteCircuitPeeringIdModel ExpressRouteCircuitPeering { get; set; }

    [JsonPropertyName("expressRouteGatewayBypass")]
    public bool? ExpressRouteGatewayBypass { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routingConfiguration")]
    public RoutingConfigurationModel? RoutingConfiguration { get; set; }

    [JsonPropertyName("routingWeight")]
    public int? RoutingWeight { get; set; }
}
