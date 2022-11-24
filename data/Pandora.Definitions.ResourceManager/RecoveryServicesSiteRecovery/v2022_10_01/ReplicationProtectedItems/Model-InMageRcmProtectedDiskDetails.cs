using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class InMageRcmProtectedDiskDetailsModel
{
    [JsonPropertyName("capacityInBytes")]
    public int? CapacityInBytes { get; set; }

    [JsonPropertyName("dataPendingAtSourceAgentInMB")]
    public float? DataPendingAtSourceAgentInMB { get; set; }

    [JsonPropertyName("dataPendingInLogDataStoreInMB")]
    public float? DataPendingInLogDataStoreInMB { get; set; }

    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskType")]
    public DiskAccountTypeConstant? DiskType { get; set; }

    [JsonPropertyName("irDetails")]
    public InMageRcmSyncDetailsModel? IrDetails { get; set; }

    [JsonPropertyName("isInitialReplicationComplete")]
    public string? IsInitialReplicationComplete { get; set; }

    [JsonPropertyName("isOSDisk")]
    public string? IsOSDisk { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("resyncDetails")]
    public InMageRcmSyncDetailsModel? ResyncDetails { get; set; }

    [JsonPropertyName("seedBlobUri")]
    public string? SeedBlobUri { get; set; }

    [JsonPropertyName("seedManagedDiskId")]
    public string? SeedManagedDiskId { get; set; }

    [JsonPropertyName("targetManagedDiskId")]
    public string? TargetManagedDiskId { get; set; }
}
