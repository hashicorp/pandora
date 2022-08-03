using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoscaleSettings;


internal class MetricTriggerModel
{
    [JsonPropertyName("dimensions")]
    public List<ScaleRuleMetricDimensionModel>? Dimensions { get; set; }

    [JsonPropertyName("dividePerInstance")]
    public bool? DividePerInstance { get; set; }

    [JsonPropertyName("metricName")]
    [Required]
    public string MetricName { get; set; }

    [JsonPropertyName("metricNamespace")]
    public string? MetricNamespace { get; set; }

    [JsonPropertyName("metricResourceLocation")]
    public string? MetricResourceLocation { get; set; }

    [JsonPropertyName("metricResourceUri")]
    [Required]
    public string MetricResourceUri { get; set; }

    [JsonPropertyName("operator")]
    [Required]
    public ComparisonOperationTypeConstant Operator { get; set; }

    [JsonPropertyName("statistic")]
    [Required]
    public MetricStatisticTypeConstant Statistic { get; set; }

    [JsonPropertyName("threshold")]
    [Required]
    public float Threshold { get; set; }

    [JsonPropertyName("timeAggregation")]
    [Required]
    public TimeAggregationTypeConstant TimeAggregation { get; set; }

    [JsonPropertyName("timeGrain")]
    [Required]
    public string TimeGrain { get; set; }

    [JsonPropertyName("timeWindow")]
    [Required]
    public string TimeWindow { get; set; }
}
