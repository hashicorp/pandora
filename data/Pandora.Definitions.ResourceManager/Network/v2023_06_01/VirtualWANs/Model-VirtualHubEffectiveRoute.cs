using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.VirtualWANs;


internal class VirtualHubEffectiveRouteModel
{
    [JsonPropertyName("addressPrefixes")]
    public List<string>? AddressPrefixes { get; set; }

    [JsonPropertyName("asPath")]
    public string? AsPath { get; set; }

    [JsonPropertyName("nextHopType")]
    public string? NextHopType { get; set; }

    [JsonPropertyName("nextHops")]
    public List<string>? NextHops { get; set; }

    [JsonPropertyName("routeOrigin")]
    public string? RouteOrigin { get; set; }
}
