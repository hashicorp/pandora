using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Forecast;


internal class ForecastDatasetModel
{
    [JsonPropertyName("aggregation")]
    [Required]
    public Dictionary<string, ForecastAggregationModel> Aggregation { get; set; }

    [JsonPropertyName("configuration")]
    public ForecastDatasetConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("filter")]
    public ForecastFilterModel? Filter { get; set; }

    [JsonPropertyName("granularity")]
    public GranularityTypeConstant? Granularity { get; set; }
}
