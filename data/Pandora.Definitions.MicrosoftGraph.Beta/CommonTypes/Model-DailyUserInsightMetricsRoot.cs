// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DailyUserInsightMetricsRootModel
{
    [JsonPropertyName("activeUsers")]
    public List<ActiveUsersMetricModel>? ActiveUsers { get; set; }

    [JsonPropertyName("activeUsersBreakdown")]
    public List<ActiveUsersBreakdownMetricModel>? ActiveUsersBreakdown { get; set; }

    [JsonPropertyName("authentications")]
    public List<AuthenticationsMetricModel>? Authentications { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inactiveUsers")]
    public List<DailyInactiveUsersMetricModel>? InactiveUsers { get; set; }

    [JsonPropertyName("inactiveUsersByApplication")]
    public List<DailyInactiveUsersByApplicationMetricModel>? InactiveUsersByApplication { get; set; }

    [JsonPropertyName("mfaCompletions")]
    public List<MfaCompletionMetricModel>? MfaCompletions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("signUps")]
    public List<UserSignUpMetricModel>? SignUps { get; set; }

    [JsonPropertyName("summary")]
    public List<InsightSummaryModel>? Summary { get; set; }

    [JsonPropertyName("userCount")]
    public List<UserCountMetricModel>? UserCount { get; set; }
}
