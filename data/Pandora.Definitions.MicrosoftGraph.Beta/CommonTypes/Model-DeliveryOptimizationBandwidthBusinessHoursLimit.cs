// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeliveryOptimizationBandwidthBusinessHoursLimitModel
{
    [JsonPropertyName("bandwidthBeginBusinessHours")]
    public int? BandwidthBeginBusinessHours { get; set; }

    [JsonPropertyName("bandwidthEndBusinessHours")]
    public int? BandwidthEndBusinessHours { get; set; }

    [JsonPropertyName("bandwidthPercentageDuringBusinessHours")]
    public int? BandwidthPercentageDuringBusinessHours { get; set; }

    [JsonPropertyName("bandwidthPercentageOutsideBusinessHours")]
    public int? BandwidthPercentageOutsideBusinessHours { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
