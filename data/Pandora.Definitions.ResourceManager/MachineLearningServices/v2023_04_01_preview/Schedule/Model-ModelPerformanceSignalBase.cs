using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ValueForType("ModelPerformance")]
internal class ModelPerformanceSignalBaseModel : MonitoringSignalBaseModel
{
    [JsonPropertyName("baselineData")]
    [Required]
    public MonitoringInputDataModel BaselineData { get; set; }

    [JsonPropertyName("dataSegment")]
    public MonitoringDataSegmentModel? DataSegment { get; set; }

    [JsonPropertyName("metricThreshold")]
    [Required]
    public ModelPerformanceMetricThresholdBaseModel MetricThreshold { get; set; }

    [JsonPropertyName("targetData")]
    [Required]
    public MonitoringInputDataModel TargetData { get; set; }
}
