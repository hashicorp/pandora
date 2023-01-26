using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.RouteFilters;


internal class RouteFilterPropertiesFormatModel
{
    [JsonPropertyName("ipv6Peerings")]
    public List<ExpressRouteCircuitPeeringModel>? IPv6Peerings { get; set; }

    [JsonPropertyName("peerings")]
    public List<ExpressRouteCircuitPeeringModel>? Peerings { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rules")]
    public List<RouteFilterRuleModel>? Rules { get; set; }
}
