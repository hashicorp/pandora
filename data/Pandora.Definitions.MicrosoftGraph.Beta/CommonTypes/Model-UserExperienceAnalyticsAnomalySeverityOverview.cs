// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsAnomalySeverityOverviewModel
{
    [JsonPropertyName("highSeverityAnomalyCount")]
    public int? HighSeverityAnomalyCount { get; set; }

    [JsonPropertyName("informationalSeverityAnomalyCount")]
    public int? InformationalSeverityAnomalyCount { get; set; }

    [JsonPropertyName("lowSeverityAnomalyCount")]
    public int? LowSeverityAnomalyCount { get; set; }

    [JsonPropertyName("mediumSeverityAnomalyCount")]
    public int? MediumSeverityAnomalyCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
