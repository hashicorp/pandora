// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MicrosoftTunnelHealthThresholdModel
{
    [JsonPropertyName("defaultHealthyThreshold")]
    public int? DefaultHealthyThreshold { get; set; }

    [JsonPropertyName("defaultUnhealthyThreshold")]
    public int? DefaultUnhealthyThreshold { get; set; }

    [JsonPropertyName("healthyThreshold")]
    public int? HealthyThreshold { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("unhealthyThreshold")]
    public int? UnhealthyThreshold { get; set; }
}
