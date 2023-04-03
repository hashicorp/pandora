using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;


internal abstract class MultiMetricCriteriaModel
{
    [JsonPropertyName("criterionType")]
    [ProvidesTypeHint]
    [Required]
    public CriterionTypeConstant CriterionType { get; set; }

    [JsonPropertyName("dimensions")]
    public List<MetricDimensionModel>? Dimensions { get; set; }

    [JsonPropertyName("metricName")]
    [Required]
    public string MetricName { get; set; }

    [JsonPropertyName("metricNamespace")]
    public string? MetricNamespace { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("skipMetricValidation")]
    public bool? SkipMetricValidation { get; set; }

    [JsonPropertyName("timeAggregation")]
    [Required]
    public AggregationTypeEnumConstant TimeAggregation { get; set; }
}
