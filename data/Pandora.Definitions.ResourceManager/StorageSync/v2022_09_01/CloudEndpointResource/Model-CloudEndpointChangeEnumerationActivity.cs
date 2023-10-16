using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.CloudEndpointResource;


internal class CloudEndpointChangeEnumerationActivityModel
{
    [JsonPropertyName("deletesProgressPercent")]
    public int? DeletesProgressPercent { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTimestamp")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [JsonPropertyName("minutesRemaining")]
    public int? MinutesRemaining { get; set; }

    [JsonPropertyName("operationState")]
    public CloudEndpointChangeEnumerationActivityStateConstant? OperationState { get; set; }

    [JsonPropertyName("processedDirectoriesCount")]
    public int? ProcessedDirectoriesCount { get; set; }

    [JsonPropertyName("processedFilesCount")]
    public int? ProcessedFilesCount { get; set; }

    [JsonPropertyName("progressPercent")]
    public int? ProgressPercent { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startedTimestamp")]
    public DateTime? StartedTimestamp { get; set; }

    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }

    [JsonPropertyName("totalCountsState")]
    public CloudEndpointChangeEnumerationTotalCountsStateConstant? TotalCountsState { get; set; }

    [JsonPropertyName("totalDirectoriesCount")]
    public int? TotalDirectoriesCount { get; set; }

    [JsonPropertyName("totalFilesCount")]
    public int? TotalFilesCount { get; set; }

    [JsonPropertyName("totalSizeBytes")]
    public int? TotalSizeBytes { get; set; }
}
