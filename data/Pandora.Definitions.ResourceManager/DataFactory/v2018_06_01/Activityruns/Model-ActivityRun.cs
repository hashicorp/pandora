using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Activityruns;


internal class ActivityRunModel
{
    [JsonPropertyName("activityName")]
    public string? ActivityName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("activityRunEnd")]
    public DateTime? ActivityRunEnd { get; set; }

    [JsonPropertyName("activityRunId")]
    public string? ActivityRunId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("activityRunStart")]
    public DateTime? ActivityRunStart { get; set; }

    [JsonPropertyName("activityType")]
    public string? ActivityType { get; set; }

    [JsonPropertyName("durationInMs")]
    public int? DurationInMs { get; set; }

    [JsonPropertyName("error")]
    public object? Error { get; set; }

    [JsonPropertyName("input")]
    public object? Input { get; set; }

    [JsonPropertyName("linkedServiceName")]
    public string? LinkedServiceName { get; set; }

    [JsonPropertyName("output")]
    public object? Output { get; set; }

    [JsonPropertyName("pipelineName")]
    public string? PipelineName { get; set; }

    [JsonPropertyName("pipelineRunId")]
    public string? PipelineRunId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
