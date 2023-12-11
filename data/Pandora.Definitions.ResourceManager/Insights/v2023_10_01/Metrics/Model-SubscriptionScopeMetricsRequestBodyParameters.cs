using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.Metrics;


internal class SubscriptionScopeMetricsRequestBodyParametersModel
{
    [JsonPropertyName("aggregation")]
    public string? Aggregation { get; set; }

    [JsonPropertyName("autoAdjustTimegrain")]
    public bool? AutoAdjustTimegrain { get; set; }

    [JsonPropertyName("filter")]
    public string? Filter { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("metricNames")]
    public string? MetricNames { get; set; }

    [JsonPropertyName("metricNamespace")]
    public string? MetricNamespace { get; set; }

    [JsonPropertyName("orderBy")]
    public string? OrderBy { get; set; }

    [JsonPropertyName("resultType")]
    public MetricResultTypeConstant? ResultType { get; set; }

    [JsonPropertyName("rollUpBy")]
    public string? RollUpBy { get; set; }

    [JsonPropertyName("timespan")]
    public string? Timespan { get; set; }

    [JsonPropertyName("top")]
    public int? Top { get; set; }

    [JsonPropertyName("validateDimensions")]
    public bool? ValidateDimensions { get; set; }
}
