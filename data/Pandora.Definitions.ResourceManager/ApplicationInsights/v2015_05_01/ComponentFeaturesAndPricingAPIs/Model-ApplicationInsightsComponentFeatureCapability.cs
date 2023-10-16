using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentFeaturesAndPricingAPIs;


internal class ApplicationInsightsComponentFeatureCapabilityModel
{
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("MeterId")]
    public string? MeterId { get; set; }

    [JsonPropertyName("MeterRateFrequency")]
    public string? MeterRateFrequency { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("Unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("Value")]
    public string? Value { get; set; }
}
