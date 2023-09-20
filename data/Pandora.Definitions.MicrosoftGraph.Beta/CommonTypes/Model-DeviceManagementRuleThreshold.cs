// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementRuleThresholdModel
{
    [JsonPropertyName("aggregation")]
    public DeviceManagementRuleThresholdAggregationConstant? Aggregation { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operator")]
    public DeviceManagementRuleThresholdOperatorConstant? Operator { get; set; }

    [JsonPropertyName("target")]
    public int? Target { get; set; }
}
