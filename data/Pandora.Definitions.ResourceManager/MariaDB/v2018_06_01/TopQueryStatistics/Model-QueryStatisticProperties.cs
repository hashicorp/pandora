using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.TopQueryStatistics;


internal class QueryStatisticPropertiesModel
{
    [JsonPropertyName("aggregationFunction")]
    public string? AggregationFunction { get; set; }

    [JsonPropertyName("databaseNames")]
    public List<string>? DatabaseNames { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("metricDisplayName")]
    public string? MetricDisplayName { get; set; }

    [JsonPropertyName("metricName")]
    public string? MetricName { get; set; }

    [JsonPropertyName("metricValue")]
    public float? MetricValue { get; set; }

    [JsonPropertyName("metricValueUnit")]
    public string? MetricValueUnit { get; set; }

    [JsonPropertyName("queryExecutionCount")]
    public int? QueryExecutionCount { get; set; }

    [JsonPropertyName("queryId")]
    public string? QueryId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
