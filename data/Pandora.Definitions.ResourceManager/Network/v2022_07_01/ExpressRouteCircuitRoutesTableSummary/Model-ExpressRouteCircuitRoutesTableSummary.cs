using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCircuitRoutesTableSummary;


internal class ExpressRouteCircuitRoutesTableSummaryModel
{
    [JsonPropertyName("as")]
    public int? As { get; set; }

    [JsonPropertyName("neighbor")]
    public string? Neighbor { get; set; }

    [JsonPropertyName("statePfxRcd")]
    public string? StatePfxRcd { get; set; }

    [JsonPropertyName("upDown")]
    public string? UpDown { get; set; }

    [JsonPropertyName("v")]
    public int? V { get; set; }
}
