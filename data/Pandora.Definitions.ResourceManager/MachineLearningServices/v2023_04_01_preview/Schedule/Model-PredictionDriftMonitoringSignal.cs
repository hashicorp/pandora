using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ValueForType("PredictionDrift")]
internal class PredictionDriftMonitoringSignalModel : MonitoringSignalBaseModel
{
    [JsonPropertyName("baselineData")]
    [Required]
    public MonitoringInputDataModel BaselineData { get; set; }

    [JsonPropertyName("metricThresholds")]
    [Required]
    public List<PredictionDriftMetricThresholdBaseModel> MetricThresholds { get; set; }

    [JsonPropertyName("modelType")]
    [Required]
    public MonitoringModelTypeConstant ModelType { get; set; }

    [JsonPropertyName("targetData")]
    [Required]
    public MonitoringInputDataModel TargetData { get; set; }
}
