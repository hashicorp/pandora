using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;


internal class DetectorAbnormalTimePeriodModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("metaData")]
    public List<List<NameValuePairModel>>? MetaData { get; set; }

    [JsonPropertyName("priority")]
    public float? Priority { get; set; }

    [JsonPropertyName("solutions")]
    public List<SolutionModel>? Solutions { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("type")]
    public IssueTypeConstant? Type { get; set; }
}
