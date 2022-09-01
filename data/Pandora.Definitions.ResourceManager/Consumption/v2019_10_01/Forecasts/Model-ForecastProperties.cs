using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Forecasts;


internal class ForecastPropertiesModel
{
    [JsonPropertyName("charge")]
    public float? Charge { get; set; }

    [JsonPropertyName("chargeType")]
    public ChargeTypeConstant? ChargeType { get; set; }

    [JsonPropertyName("confidenceLevels")]
    public List<ForecastPropertiesConfidenceLevelsInlinedModel>? ConfidenceLevels { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("grain")]
    public GrainConstant? Grain { get; set; }

    [JsonPropertyName("usageDate")]
    public string? UsageDate { get; set; }
}
