using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Prediction;


internal class PredictionResponsePropertiesModel
{
    [JsonPropertyName("category")]
    public CategoryConstant? Category { get; set; }

    [JsonPropertyName("extendedProperties")]
    public object? ExtendedProperties { get; set; }

    [JsonPropertyName("impact")]
    public ImpactConstant? Impact { get; set; }

    [JsonPropertyName("impactedField")]
    public string? ImpactedField { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("predictionType")]
    public PredictionTypeConstant? PredictionType { get; set; }

    [JsonPropertyName("shortDescription")]
    public ShortDescriptionModel? ShortDescription { get; set; }
}
