using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ValueForType("TextClassification")]
internal class TextClassificationModel : AutoMLVerticalModel
{
    [JsonPropertyName("featurizationSettings")]
    public FeaturizationSettingsModel? FeaturizationSettings { get; set; }

    [JsonPropertyName("fixedParameters")]
    public NlpFixedParametersModel? FixedParameters { get; set; }

    [JsonPropertyName("limitSettings")]
    public NlpVerticalLimitSettingsModel? LimitSettings { get; set; }

    [JsonPropertyName("primaryMetric")]
    public ClassificationPrimaryMetricsConstant? PrimaryMetric { get; set; }

    [JsonPropertyName("searchSpace")]
    public List<NlpParameterSubspaceModel>? SearchSpace { get; set; }

    [JsonPropertyName("sweepSettings")]
    public NlpSweepSettingsModel? SweepSettings { get; set; }

    [JsonPropertyName("validationData")]
    public JobInputModel? ValidationData { get; set; }
}
