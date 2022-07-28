using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.RouteFilters;


internal class IPv6ExpressRouteCircuitPeeringConfigModel
{
    [JsonPropertyName("microsoftPeeringConfig")]
    public ExpressRouteCircuitPeeringConfigModel? MicrosoftPeeringConfig { get; set; }

    [JsonPropertyName("primaryPeerAddressPrefix")]
    public string? PrimaryPeerAddressPrefix { get; set; }

    [JsonPropertyName("routeFilter")]
    public SubResourceModel? RouteFilter { get; set; }

    [JsonPropertyName("secondaryPeerAddressPrefix")]
    public string? SecondaryPeerAddressPrefix { get; set; }

    [JsonPropertyName("state")]
    public ExpressRouteCircuitPeeringStateConstant? State { get; set; }
}
