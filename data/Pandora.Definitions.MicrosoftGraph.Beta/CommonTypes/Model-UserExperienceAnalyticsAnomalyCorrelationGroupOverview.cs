// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsAnomalyCorrelationGroupOverviewModel
{
    [JsonPropertyName("anomalyCorrelationGroupCount")]
    public int? AnomalyCorrelationGroupCount { get; set; }

    [JsonPropertyName("anomalyId")]
    public string? AnomalyId { get; set; }

    [JsonPropertyName("correlationGroupAnomalousDeviceCount")]
    public int? CorrelationGroupAnomalousDeviceCount { get; set; }

    [JsonPropertyName("correlationGroupAtRiskDeviceCount")]
    public int? CorrelationGroupAtRiskDeviceCount { get; set; }

    [JsonPropertyName("correlationGroupDeviceCount")]
    public int? CorrelationGroupDeviceCount { get; set; }

    [JsonPropertyName("correlationGroupFeatures")]
    public List<UserExperienceAnalyticsAnomalyCorrelationGroupFeatureModel>? CorrelationGroupFeatures { get; set; }

    [JsonPropertyName("correlationGroupId")]
    public string? CorrelationGroupId { get; set; }

    [JsonPropertyName("correlationGroupPrevalence")]
    public UserExperienceAnalyticsAnomalyCorrelationGroupOverviewCorrelationGroupPrevalenceConstant? CorrelationGroupPrevalence { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalDeviceCount")]
    public int? TotalDeviceCount { get; set; }
}
