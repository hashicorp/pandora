using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class InMageAzureV2ProtectedDiskDetailsModel
{
    [JsonPropertyName("diskCapacityInBytes")]
    public int? DiskCapacityInBytes { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskResized")]
    public string? DiskResized { get; set; }

    [JsonPropertyName("fileSystemCapacityInBytes")]
    public int? FileSystemCapacityInBytes { get; set; }

    [JsonPropertyName("healthErrorCode")]
    public string? HealthErrorCode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRpoCalculatedTime")]
    public DateTime? LastRpoCalculatedTime { get; set; }

    [JsonPropertyName("progressHealth")]
    public string? ProgressHealth { get; set; }

    [JsonPropertyName("progressStatus")]
    public string? ProgressStatus { get; set; }

    [JsonPropertyName("protectionStage")]
    public string? ProtectionStage { get; set; }

    [JsonPropertyName("psDataInMegaBytes")]
    public float? PsDataInMegaBytes { get; set; }

    [JsonPropertyName("resyncDurationInSeconds")]
    public int? ResyncDurationInSeconds { get; set; }

    [JsonPropertyName("resyncLast15MinutesTransferredBytes")]
    public int? ResyncLast15MinutesTransferredBytes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("resyncLastDataTransferTimeUTC")]
    public DateTime? ResyncLastDataTransferTimeUTC { get; set; }

    [JsonPropertyName("resyncProcessedBytes")]
    public int? ResyncProcessedBytes { get; set; }

    [JsonPropertyName("resyncProgressPercentage")]
    public int? ResyncProgressPercentage { get; set; }

    [JsonPropertyName("resyncRequired")]
    public string? ResyncRequired { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("resyncStartTime")]
    public DateTime? ResyncStartTime { get; set; }

    [JsonPropertyName("resyncTotalTransferredBytes")]
    public int? ResyncTotalTransferredBytes { get; set; }

    [JsonPropertyName("rpoInSeconds")]
    public int? RpoInSeconds { get; set; }

    [JsonPropertyName("secondsToTakeSwitchProvider")]
    public int? SecondsToTakeSwitchProvider { get; set; }

    [JsonPropertyName("sourceDataInMegaBytes")]
    public float? SourceDataInMegaBytes { get; set; }

    [JsonPropertyName("targetDataInMegaBytes")]
    public float? TargetDataInMegaBytes { get; set; }
}
