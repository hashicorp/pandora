using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ValueForType("Custom")]
internal class CustomMonitoringSignalModel : MonitoringSignalBaseModel
{
    [JsonPropertyName("componentId")]
    [Required]
    public string ComponentId { get; set; }

    [JsonPropertyName("inputAssets")]
    public Dictionary<string, MonitoringInputDataModel>? InputAssets { get; set; }

    [JsonPropertyName("metricThresholds")]
    [Required]
    public List<CustomMetricThresholdModel> MetricThresholds { get; set; }
}
