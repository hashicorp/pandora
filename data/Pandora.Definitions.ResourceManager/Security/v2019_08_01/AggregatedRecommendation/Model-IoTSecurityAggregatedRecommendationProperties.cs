using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.AggregatedRecommendation;


internal class IoTSecurityAggregatedRecommendationPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detectedBy")]
    public string? DetectedBy { get; set; }

    [JsonPropertyName("healthyDevices")]
    public int? HealthyDevices { get; set; }

    [JsonPropertyName("logAnalyticsQuery")]
    public string? LogAnalyticsQuery { get; set; }

    [JsonPropertyName("recommendationDisplayName")]
    public string? RecommendationDisplayName { get; set; }

    [JsonPropertyName("recommendationName")]
    public string? RecommendationName { get; set; }

    [JsonPropertyName("recommendationTypeId")]
    public string? RecommendationTypeId { get; set; }

    [JsonPropertyName("remediationSteps")]
    public string? RemediationSteps { get; set; }

    [JsonPropertyName("reportedSeverity")]
    public ReportedSeverityConstant? ReportedSeverity { get; set; }

    [JsonPropertyName("unhealthyDeviceCount")]
    public int? UnhealthyDeviceCount { get; set; }
}
