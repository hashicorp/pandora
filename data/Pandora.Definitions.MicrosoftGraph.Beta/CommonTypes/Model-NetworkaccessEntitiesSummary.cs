// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessEntitiesSummaryModel
{
    [JsonPropertyName("deviceCount")]
    public int? DeviceCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("trafficType")]
    public NetworkaccessEntitiesSummaryTrafficTypeConstant? TrafficType { get; set; }

    [JsonPropertyName("userCount")]
    public int? UserCount { get; set; }

    [JsonPropertyName("workloadCount")]
    public int? WorkloadCount { get; set; }
}
