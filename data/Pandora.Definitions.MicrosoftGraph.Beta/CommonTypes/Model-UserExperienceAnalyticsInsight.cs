// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsInsightModel
{
    [JsonPropertyName("insightId")]
    public string? InsightId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("severity")]
    public UserExperienceAnalyticsInsightSeverityConstant? Severity { get; set; }

    [JsonPropertyName("userExperienceAnalyticsMetricId")]
    public string? UserExperienceAnalyticsMetricId { get; set; }

    [JsonPropertyName("values")]
    public List<UserExperienceAnalyticsInsightValueModel>? Values { get; set; }
}
