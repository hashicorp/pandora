using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;


internal class ConditionModel
{
    [JsonPropertyName("dimensions")]
    public List<DimensionModel>? Dimensions { get; set; }

    [JsonPropertyName("failingPeriods")]
    public ConditionFailingPeriodsModel? FailingPeriods { get; set; }

    [JsonPropertyName("metricMeasureColumn")]
    public string? MetricMeasureColumn { get; set; }

    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    [JsonPropertyName("operator")]
    public ConditionOperatorConstant? Operator { get; set; }

    [JsonPropertyName("query")]
    public string? Query { get; set; }

    [JsonPropertyName("resourceIdColumn")]
    public string? ResourceIdColumn { get; set; }

    [JsonPropertyName("threshold")]
    public float? Threshold { get; set; }

    [JsonPropertyName("timeAggregation")]
    public TimeAggregationConstant? TimeAggregation { get; set; }
}
