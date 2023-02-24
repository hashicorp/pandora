using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.PipelineRuns;


internal class PipelineRunModel
{
    [JsonPropertyName("durationInMs")]
    public int? DurationInMs { get; set; }

    [JsonPropertyName("invokedBy")]
    public PipelineRunInvokedByModel? InvokedBy { get; set; }

    [JsonPropertyName("isLatest")]
    public bool? IsLatest { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("pipelineName")]
    public string? PipelineName { get; set; }

    [JsonPropertyName("runDimensions")]
    public Dictionary<string, string>? RunDimensions { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("runEnd")]
    public DateTime? RunEnd { get; set; }

    [JsonPropertyName("runGroupId")]
    public string? RunGroupId { get; set; }

    [JsonPropertyName("runId")]
    public string? RunId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("runStart")]
    public DateTime? RunStart { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
