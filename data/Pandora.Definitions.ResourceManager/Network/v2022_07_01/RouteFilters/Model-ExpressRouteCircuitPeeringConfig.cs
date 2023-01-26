using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.RouteFilters;


internal class ExpressRouteCircuitPeeringConfigModel
{
    [JsonPropertyName("advertisedCommunities")]
    public List<string>? AdvertisedCommunities { get; set; }

    [JsonPropertyName("advertisedPublicPrefixes")]
    public List<string>? AdvertisedPublicPrefixes { get; set; }

    [JsonPropertyName("advertisedPublicPrefixesState")]
    public ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant? AdvertisedPublicPrefixesState { get; set; }

    [JsonPropertyName("customerASN")]
    public int? CustomerASN { get; set; }

    [JsonPropertyName("legacyMode")]
    public int? LegacyMode { get; set; }

    [JsonPropertyName("routingRegistryName")]
    public string? RoutingRegistryName { get; set; }
}
