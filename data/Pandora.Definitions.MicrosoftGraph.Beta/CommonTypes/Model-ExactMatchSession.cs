// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExactMatchSessionModel
{
    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    [JsonPropertyName("completionDateTime")]
    public DateTime? CompletionDateTime { get; set; }

    [JsonPropertyName("creationDateTime")]
    public DateTime? CreationDateTime { get; set; }

    [JsonPropertyName("dataStoreId")]
    public string? DataStoreId { get; set; }

    [JsonPropertyName("dataUploadURI")]
    public string? DataUploadURI { get; set; }

    [JsonPropertyName("error")]
    public ClassificationErrorModel? Error { get; set; }

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("processingCompletionDateTime")]
    public DateTime? ProcessingCompletionDateTime { get; set; }

    [JsonPropertyName("remainingBlockCount")]
    public int? RemainingBlockCount { get; set; }

    [JsonPropertyName("remainingJobCount")]
    public int? RemainingJobCount { get; set; }

    [JsonPropertyName("rowsPerBlock")]
    public int? RowsPerBlock { get; set; }

    [JsonPropertyName("salt")]
    public string? Salt { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("totalBlockCount")]
    public int? TotalBlockCount { get; set; }

    [JsonPropertyName("totalJobCount")]
    public int? TotalJobCount { get; set; }

    [JsonPropertyName("uploadAgent")]
    public ExactMatchUploadAgentModel? UploadAgent { get; set; }

    [JsonPropertyName("uploadAgentId")]
    public string? UploadAgentId { get; set; }

    [JsonPropertyName("uploadCompletionDateTime")]
    public DateTime? UploadCompletionDateTime { get; set; }
}
