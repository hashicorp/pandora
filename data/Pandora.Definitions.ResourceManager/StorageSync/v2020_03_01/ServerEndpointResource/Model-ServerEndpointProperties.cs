using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;


internal class ServerEndpointPropertiesModel
{
    [JsonPropertyName("cloudTiering")]
    public FeatureStatusConstant? CloudTiering { get; set; }

    [JsonPropertyName("cloudTieringStatus")]
    public ServerEndpointCloudTieringStatusModel? CloudTieringStatus { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("initialDownloadPolicy")]
    public InitialDownloadPolicyConstant? InitialDownloadPolicy { get; set; }

    [JsonPropertyName("lastOperationName")]
    public string? LastOperationName { get; set; }

    [JsonPropertyName("lastWorkflowId")]
    public string? LastWorkflowId { get; set; }

    [JsonPropertyName("localCacheMode")]
    public LocalCacheModeConstant? LocalCacheMode { get; set; }

    [JsonPropertyName("offlineDataTransfer")]
    public FeatureStatusConstant? OfflineDataTransfer { get; set; }

    [JsonPropertyName("offlineDataTransferShareName")]
    public string? OfflineDataTransferShareName { get; set; }

    [JsonPropertyName("offlineDataTransferStorageAccountResourceId")]
    public string? OfflineDataTransferStorageAccountResourceId { get; set; }

    [JsonPropertyName("offlineDataTransferStorageAccountTenantId")]
    public string? OfflineDataTransferStorageAccountTenantId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("recallStatus")]
    public ServerEndpointRecallStatusModel? RecallStatus { get; set; }

    [JsonPropertyName("serverLocalPath")]
    public string? ServerLocalPath { get; set; }

    [JsonPropertyName("serverResourceId")]
    public string? ServerResourceId { get; set; }

    [JsonPropertyName("syncStatus")]
    public ServerEndpointSyncStatusModel? SyncStatus { get; set; }

    [JsonPropertyName("tierFilesOlderThanDays")]
    public int? TierFilesOlderThanDays { get; set; }

    [JsonPropertyName("volumeFreeSpacePercent")]
    public int? VolumeFreeSpacePercent { get; set; }
}
