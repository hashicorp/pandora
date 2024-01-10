using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentFeaturesAndPricingAPIs;


internal class ApplicationInsightsComponentFeatureModel
{
    [JsonPropertyName("Capabilities")]
    public List<ApplicationInsightsComponentFeatureCapabilityModel>? Capabilities { get; set; }

    [JsonPropertyName("FeatureName")]
    public string? FeatureName { get; set; }

    [JsonPropertyName("IsHidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("IsMainFeature")]
    public bool? IsMainFeature { get; set; }

    [JsonPropertyName("MeterId")]
    public string? MeterId { get; set; }

    [JsonPropertyName("MeterRateFrequency")]
    public string? MeterRateFrequency { get; set; }

    [JsonPropertyName("ResouceId")]
    public string? ResouceId { get; set; }

    [JsonPropertyName("SupportedAddonFeatures")]
    public string? SupportedAddonFeatures { get; set; }

    [JsonPropertyName("Title")]
    public string? Title { get; set; }
}
