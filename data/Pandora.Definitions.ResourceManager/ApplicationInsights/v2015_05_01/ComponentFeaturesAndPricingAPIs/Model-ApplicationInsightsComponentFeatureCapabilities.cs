using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentFeaturesAndPricingAPIs;


internal class ApplicationInsightsComponentFeatureCapabilitiesModel
{
    [JsonPropertyName("AnalyticsIntegration")]
    public bool? AnalyticsIntegration { get; set; }

    [JsonPropertyName("ApiAccessLevel")]
    public string? ApiAccessLevel { get; set; }

    [JsonPropertyName("ApplicationMap")]
    public bool? ApplicationMap { get; set; }

    [JsonPropertyName("BurstThrottlePolicy")]
    public string? BurstThrottlePolicy { get; set; }

    [JsonPropertyName("DailyCap")]
    public float? DailyCap { get; set; }

    [JsonPropertyName("DailyCapResetTime")]
    public float? DailyCapResetTime { get; set; }

    [JsonPropertyName("LiveStreamMetrics")]
    public bool? LiveStreamMetrics { get; set; }

    [JsonPropertyName("MetadataClass")]
    public string? MetadataClass { get; set; }

    [JsonPropertyName("MultipleStepWebTest")]
    public bool? MultipleStepWebTest { get; set; }

    [JsonPropertyName("OpenSchema")]
    public bool? OpenSchema { get; set; }

    [JsonPropertyName("PowerBIIntegration")]
    public bool? PowerBIIntegration { get; set; }

    [JsonPropertyName("ProactiveDetection")]
    public bool? ProactiveDetection { get; set; }

    [JsonPropertyName("SupportExportData")]
    public bool? SupportExportData { get; set; }

    [JsonPropertyName("ThrottleRate")]
    public float? ThrottleRate { get; set; }

    [JsonPropertyName("TrackingType")]
    public string? TrackingType { get; set; }

    [JsonPropertyName("WorkItemIntegration")]
    public bool? WorkItemIntegration { get; set; }
}
