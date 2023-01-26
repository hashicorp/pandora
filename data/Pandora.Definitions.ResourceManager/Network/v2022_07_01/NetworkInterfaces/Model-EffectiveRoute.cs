using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkInterfaces;


internal class EffectiveRouteModel
{
    [JsonPropertyName("addressPrefix")]
    public List<string>? AddressPrefix { get; set; }

    [JsonPropertyName("disableBgpRoutePropagation")]
    public bool? DisableBgpRoutePropagation { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nextHopIpAddress")]
    public List<string>? NextHopIPAddress { get; set; }

    [JsonPropertyName("nextHopType")]
    public RouteNextHopTypeConstant? NextHopType { get; set; }

    [JsonPropertyName("source")]
    public EffectiveRouteSourceConstant? Source { get; set; }

    [JsonPropertyName("state")]
    public EffectiveRouteStateConstant? State { get; set; }
}
