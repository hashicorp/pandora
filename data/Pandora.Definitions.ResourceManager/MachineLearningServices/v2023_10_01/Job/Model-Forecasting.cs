using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Job;

[ValueForType("Forecasting")]
internal class ForecastingModel : AutoMLVerticalModel
{
    [JsonPropertyName("cvSplitColumnNames")]
    public List<string>? CvSplitColumnNames { get; set; }

    [JsonPropertyName("featurizationSettings")]
    public TableVerticalFeaturizationSettingsModel? FeaturizationSettings { get; set; }

    [JsonPropertyName("forecastingSettings")]
    public ForecastingSettingsModel? ForecastingSettings { get; set; }

    [JsonPropertyName("limitSettings")]
    public TableVerticalLimitSettingsModel? LimitSettings { get; set; }

    [JsonPropertyName("nCrossValidations")]
    public NCrossValidationsModel? NCrossValidations { get; set; }

    [JsonPropertyName("primaryMetric")]
    public ForecastingPrimaryMetricsConstant? PrimaryMetric { get; set; }

    [JsonPropertyName("testData")]
    public MLTableJobInputModel? TestData { get; set; }

    [JsonPropertyName("testDataSize")]
    public float? TestDataSize { get; set; }

    [JsonPropertyName("trainingSettings")]
    public ForecastingTrainingSettingsModel? TrainingSettings { get; set; }

    [JsonPropertyName("validationData")]
    public MLTableJobInputModel? ValidationData { get; set; }

    [JsonPropertyName("validationDataSize")]
    public float? ValidationDataSize { get; set; }

    [JsonPropertyName("weightColumnName")]
    public string? WeightColumnName { get; set; }
}
