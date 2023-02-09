using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.CloudEndpointResource;


internal class PreRestoreRequestModel
{
    [JsonPropertyName("azureFileShareUri")]
    public string? AzureFileShareUri { get; set; }

    [JsonPropertyName("backupMetadataPropertyBag")]
    public string? BackupMetadataPropertyBag { get; set; }

    [JsonPropertyName("partition")]
    public string? Partition { get; set; }

    [JsonPropertyName("pauseWaitForSyncDrainTimePeriodInSeconds")]
    public int? PauseWaitForSyncDrainTimePeriodInSeconds { get; set; }

    [JsonPropertyName("replicaGroup")]
    public string? ReplicaGroup { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("restoreFileSpec")]
    public List<RestoreFileSpecModel>? RestoreFileSpec { get; set; }

    [JsonPropertyName("sourceAzureFileShareUri")]
    public string? SourceAzureFileShareUri { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
