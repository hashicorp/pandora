// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserExperienceAnalyticsBaselineModel
{
    [JsonPropertyName("appHealthMetrics")]
    public UserExperienceAnalyticsCategoryModel? AppHealthMetrics { get; set; }

    [JsonPropertyName("batteryHealthMetrics")]
    public UserExperienceAnalyticsCategoryModel? BatteryHealthMetrics { get; set; }

    [JsonPropertyName("bestPracticesMetrics")]
    public UserExperienceAnalyticsCategoryModel? BestPracticesMetrics { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deviceBootPerformanceMetrics")]
    public UserExperienceAnalyticsCategoryModel? DeviceBootPerformanceMetrics { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isBuiltIn")]
    public bool? IsBuiltIn { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rebootAnalyticsMetrics")]
    public UserExperienceAnalyticsCategoryModel? RebootAnalyticsMetrics { get; set; }

    [JsonPropertyName("resourcePerformanceMetrics")]
    public UserExperienceAnalyticsCategoryModel? ResourcePerformanceMetrics { get; set; }

    [JsonPropertyName("workFromAnywhereMetrics")]
    public UserExperienceAnalyticsCategoryModel? WorkFromAnywhereMetrics { get; set; }
}
