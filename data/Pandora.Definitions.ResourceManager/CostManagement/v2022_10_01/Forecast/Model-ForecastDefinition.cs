using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Forecast;


internal class ForecastDefinitionModel
{
    [JsonPropertyName("dataset")]
    [Required]
    public ForecastDatasetModel Dataset { get; set; }

    [JsonPropertyName("includeActualCost")]
    public bool? IncludeActualCost { get; set; }

    [JsonPropertyName("includeFreshPartialCost")]
    public bool? IncludeFreshPartialCost { get; set; }

    [JsonPropertyName("timePeriod")]
    public ForecastTimePeriodModel? TimePeriod { get; set; }

    [JsonPropertyName("timeframe")]
    [Required]
    public ForecastTimeframeConstant Timeframe { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ForecastTypeConstant Type { get; set; }
}
