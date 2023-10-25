using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstances;


internal class QueryStatisticsPropertiesModel
{
    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("endTime")]
    public string? EndTime { get; set; }

    [JsonPropertyName("intervals")]
    public List<QueryMetricIntervalModel>? Intervals { get; set; }

    [JsonPropertyName("queryId")]
    public string? QueryId { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }
}
