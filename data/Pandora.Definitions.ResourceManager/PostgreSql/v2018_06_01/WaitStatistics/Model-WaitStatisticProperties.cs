using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2018_06_01.WaitStatistics;


internal class WaitStatisticPropertiesModel
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("eventName")]
    public string? EventName { get; set; }

    [JsonPropertyName("eventTypeName")]
    public string? EventTypeName { get; set; }

    [JsonPropertyName("queryId")]
    public int? QueryId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("totalTimeInMs")]
    public float? TotalTimeInMs { get; set; }

    [JsonPropertyName("userId")]
    public int? UserId { get; set; }
}
