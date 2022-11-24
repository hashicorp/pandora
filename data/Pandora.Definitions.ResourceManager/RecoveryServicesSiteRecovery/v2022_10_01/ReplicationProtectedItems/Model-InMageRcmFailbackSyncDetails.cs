using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class InMageRcmFailbackSyncDetailsModel
{
    [JsonPropertyName("last15MinutesTransferredBytes")]
    public int? Last15MinutesTransferredBytes { get; set; }

    [JsonPropertyName("lastDataTransferTimeUtc")]
    public string? LastDataTransferTimeUtc { get; set; }

    [JsonPropertyName("lastRefreshTime")]
    public string? LastRefreshTime { get; set; }

    [JsonPropertyName("processedBytes")]
    public int? ProcessedBytes { get; set; }

    [JsonPropertyName("progressHealth")]
    public DiskReplicationProgressHealthConstant? ProgressHealth { get; set; }

    [JsonPropertyName("progressPercentage")]
    public int? ProgressPercentage { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }

    [JsonPropertyName("transferredBytes")]
    public int? TransferredBytes { get; set; }
}
