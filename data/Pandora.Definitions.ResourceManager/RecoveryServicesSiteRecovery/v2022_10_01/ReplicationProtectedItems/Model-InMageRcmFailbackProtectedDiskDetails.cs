using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class InMageRcmFailbackProtectedDiskDetailsModel
{
    [JsonPropertyName("capacityInBytes")]
    public int? CapacityInBytes { get; set; }

    [JsonPropertyName("dataPendingAtSourceAgentInMB")]
    public float? DataPendingAtSourceAgentInMB { get; set; }

    [JsonPropertyName("dataPendingInLogDataStoreInMB")]
    public float? DataPendingInLogDataStoreInMB { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskUuid")]
    public string? DiskUuid { get; set; }

    [JsonPropertyName("irDetails")]
    public InMageRcmFailbackSyncDetailsModel? IrDetails { get; set; }

    [JsonPropertyName("isInitialReplicationComplete")]
    public string? IsInitialReplicationComplete { get; set; }

    [JsonPropertyName("isOSDisk")]
    public string? IsOSDisk { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSyncTime")]
    public DateTime? LastSyncTime { get; set; }

    [JsonPropertyName("resyncDetails")]
    public InMageRcmFailbackSyncDetailsModel? ResyncDetails { get; set; }
}
