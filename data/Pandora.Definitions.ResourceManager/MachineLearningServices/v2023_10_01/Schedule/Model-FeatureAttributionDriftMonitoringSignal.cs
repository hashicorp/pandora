using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ValueForType("FeatureAttributionDrift")]
internal class FeatureAttributionDriftMonitoringSignalModel : MonitoringSignalBaseModel
{
    [JsonPropertyName("featureDataTypeOverride")]
    public Dictionary<string, MonitoringFeatureDataTypeConstant>? FeatureDataTypeOverride { get; set; }

    [JsonPropertyName("featureImportanceSettings")]
    [Required]
    public FeatureImportanceSettingsModel FeatureImportanceSettings { get; set; }

    [JsonPropertyName("metricThreshold")]
    [Required]
    public FeatureAttributionMetricThresholdModel MetricThreshold { get; set; }

    [JsonPropertyName("productionData")]
    [Required]
    public List<MonitoringInputDataBaseModel> ProductionData { get; set; }

    [JsonPropertyName("referenceData")]
    [Required]
    public MonitoringInputDataBaseModel ReferenceData { get; set; }
}
