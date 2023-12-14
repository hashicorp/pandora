using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedInstances;


internal class TopQueriesModel
{
    [JsonPropertyName("aggregationFunction")]
    public string? AggregationFunction { get; set; }

    [JsonPropertyName("endTime")]
    public string? EndTime { get; set; }

    [JsonPropertyName("intervalType")]
    public QueryTimeGrainTypeConstant? IntervalType { get; set; }

    [JsonPropertyName("numberOfQueries")]
    public int? NumberOfQueries { get; set; }

    [JsonPropertyName("observationMetric")]
    public string? ObservationMetric { get; set; }

    [JsonPropertyName("queries")]
    public List<QueryStatisticsPropertiesModel>? Queries { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }
}
