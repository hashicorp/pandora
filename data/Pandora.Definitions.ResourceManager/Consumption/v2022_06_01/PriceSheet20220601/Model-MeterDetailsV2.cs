using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2022_06_01.PriceSheet20220601;


internal class MeterDetailsV2Model
{
    [JsonPropertyName("meterCategory")]
    public string? MeterCategory { get; set; }

    [JsonPropertyName("meterLocation")]
    public string? MeterLocation { get; set; }

    [JsonPropertyName("meterName")]
    public string? MeterName { get; set; }

    [JsonPropertyName("meterSubCategory")]
    public string? MeterSubCategory { get; set; }

    [JsonPropertyName("pretaxStandardRate")]
    public float? PretaxStandardRate { get; set; }

    [JsonPropertyName("serviceName")]
    public string? ServiceName { get; set; }

    [JsonPropertyName("serviceTier")]
    public string? ServiceTier { get; set; }

    [JsonPropertyName("totalIncludedQuantity")]
    public float? TotalIncludedQuantity { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
