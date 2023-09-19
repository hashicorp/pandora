// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserExperienceAnalyticsAnomalyModel
{
    [JsonPropertyName("anomalyFirstOccurrenceDateTime")]
    public DateTime? AnomalyFirstOccurrenceDateTime { get; set; }

    [JsonPropertyName("anomalyId")]
    public string? AnomalyId { get; set; }

    [JsonPropertyName("anomalyLatestOccurrenceDateTime")]
    public DateTime? AnomalyLatestOccurrenceDateTime { get; set; }

    [JsonPropertyName("anomalyName")]
    public string? AnomalyName { get; set; }

    [JsonPropertyName("anomalyType")]
    public UserExperienceAnalyticsAnomalyAnomalyTypeConstant? AnomalyType { get; set; }

    [JsonPropertyName("assetName")]
    public string? AssetName { get; set; }

    [JsonPropertyName("assetPublisher")]
    public string? AssetPublisher { get; set; }

    [JsonPropertyName("assetVersion")]
    public string? AssetVersion { get; set; }

    [JsonPropertyName("detectionModelId")]
    public string? DetectionModelId { get; set; }

    [JsonPropertyName("deviceImpactedCount")]
    public int? DeviceImpactedCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issueId")]
    public string? IssueId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("severity")]
    public UserExperienceAnalyticsAnomalySeverityConstant? Severity { get; set; }

    [JsonPropertyName("state")]
    public UserExperienceAnalyticsAnomalyStateConstant? State { get; set; }
}
