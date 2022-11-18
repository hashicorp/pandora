using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;


internal class ForecastingSettingsModel
{
    [JsonPropertyName("countryOrRegionForHolidays")]
    public string? CountryOrRegionForHolidays { get; set; }

    [JsonPropertyName("cvStepSize")]
    public int? CvStepSize { get; set; }

    [JsonPropertyName("featureLags")]
    public FeatureLagsConstant? FeatureLags { get; set; }

    [JsonPropertyName("forecastHorizon")]
    public ForecastHorizonModel? ForecastHorizon { get; set; }

    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    [JsonPropertyName("seasonality")]
    public SeasonalityModel? Seasonality { get; set; }

    [JsonPropertyName("shortSeriesHandlingConfig")]
    public ShortSeriesHandlingConfigurationConstant? ShortSeriesHandlingConfig { get; set; }

    [JsonPropertyName("targetAggregateFunction")]
    public TargetAggregationFunctionConstant? TargetAggregateFunction { get; set; }

    [JsonPropertyName("targetLags")]
    public TargetLagsModel? TargetLags { get; set; }

    [JsonPropertyName("targetRollingWindowSize")]
    public TargetRollingWindowSizeModel? TargetRollingWindowSize { get; set; }

    [JsonPropertyName("timeColumnName")]
    public string? TimeColumnName { get; set; }

    [JsonPropertyName("timeSeriesIdColumnNames")]
    public List<string>? TimeSeriesIdColumnNames { get; set; }

    [JsonPropertyName("useStl")]
    public UseStlConstant? UseStl { get; set; }
}
