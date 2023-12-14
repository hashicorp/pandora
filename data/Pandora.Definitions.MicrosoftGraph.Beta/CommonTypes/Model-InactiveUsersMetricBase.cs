// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class InactiveUsersMetricBaseModel
{
    [JsonPropertyName("factDate")]
    public DateTime? FactDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inactive30DayCount")]
    public int? Inactive30DayCount { get; set; }

    [JsonPropertyName("inactive60DayCount")]
    public int? Inactive60DayCount { get; set; }

    [JsonPropertyName("inactive90DayCount")]
    public int? Inactive90DayCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
