using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_03_01.JobRuns;


internal class JobRunPropertiesModel
{
    [JsonPropertyName("agentName")]
    public string? AgentName { get; set; }

    [JsonPropertyName("agentResourceId")]
    public string? AgentResourceId { get; set; }

    [JsonPropertyName("bytesExcluded")]
    public int? BytesExcluded { get; set; }

    [JsonPropertyName("bytesFailed")]
    public int? BytesFailed { get; set; }

    [JsonPropertyName("bytesNoTransferNeeded")]
    public int? BytesNoTransferNeeded { get; set; }

    [JsonPropertyName("bytesScanned")]
    public int? BytesScanned { get; set; }

    [JsonPropertyName("bytesTransferred")]
    public int? BytesTransferred { get; set; }

    [JsonPropertyName("bytesUnsupported")]
    public int? BytesUnsupported { get; set; }

    [JsonPropertyName("error")]
    public JobRunErrorModel? Error { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("executionEndTime")]
    public DateTime? ExecutionEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("executionStartTime")]
    public DateTime? ExecutionStartTime { get; set; }

    [JsonPropertyName("itemsExcluded")]
    public int? ItemsExcluded { get; set; }

    [JsonPropertyName("itemsFailed")]
    public int? ItemsFailed { get; set; }

    [JsonPropertyName("itemsNoTransferNeeded")]
    public int? ItemsNoTransferNeeded { get; set; }

    [JsonPropertyName("itemsScanned")]
    public int? ItemsScanned { get; set; }

    [JsonPropertyName("itemsTransferred")]
    public int? ItemsTransferred { get; set; }

    [JsonPropertyName("itemsUnsupported")]
    public int? ItemsUnsupported { get; set; }

    [JsonPropertyName("jobDefinitionProperties")]
    public object? JobDefinitionProperties { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStatusUpdate")]
    public DateTime? LastStatusUpdate { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("scanStatus")]
    public JobRunScanStatusConstant? ScanStatus { get; set; }

    [JsonPropertyName("sourceName")]
    public string? SourceName { get; set; }

    [JsonPropertyName("sourceProperties")]
    public object? SourceProperties { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("status")]
    public JobRunStatusConstant? Status { get; set; }

    [JsonPropertyName("targetName")]
    public string? TargetName { get; set; }

    [JsonPropertyName("targetProperties")]
    public object? TargetProperties { get; set; }

    [JsonPropertyName("targetResourceId")]
    public string? TargetResourceId { get; set; }
}
