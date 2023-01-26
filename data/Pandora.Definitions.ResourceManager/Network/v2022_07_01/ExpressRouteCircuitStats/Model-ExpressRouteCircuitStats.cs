using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCircuitStats;


internal class ExpressRouteCircuitStatsModel
{
    [JsonPropertyName("primarybytesIn")]
    public int? PrimarybytesIn { get; set; }

    [JsonPropertyName("primarybytesOut")]
    public int? PrimarybytesOut { get; set; }

    [JsonPropertyName("secondarybytesIn")]
    public int? SecondarybytesIn { get; set; }

    [JsonPropertyName("secondarybytesOut")]
    public int? SecondarybytesOut { get; set; }
}
