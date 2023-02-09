using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;


internal class ServerEndpointCreateParametersPropertiesModel
{
    [JsonPropertyName("cloudTiering")]
    public FeatureStatusConstant? CloudTiering { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("initialDownloadPolicy")]
    public InitialDownloadPolicyConstant? InitialDownloadPolicy { get; set; }

    [JsonPropertyName("localCacheMode")]
    public LocalCacheModeConstant? LocalCacheMode { get; set; }

    [JsonPropertyName("offlineDataTransfer")]
    public FeatureStatusConstant? OfflineDataTransfer { get; set; }

    [JsonPropertyName("offlineDataTransferShareName")]
    public string? OfflineDataTransferShareName { get; set; }

    [JsonPropertyName("serverLocalPath")]
    public string? ServerLocalPath { get; set; }

    [JsonPropertyName("serverResourceId")]
    public string? ServerResourceId { get; set; }

    [JsonPropertyName("tierFilesOlderThanDays")]
    public int? TierFilesOlderThanDays { get; set; }

    [JsonPropertyName("volumeFreeSpacePercent")]
    public int? VolumeFreeSpacePercent { get; set; }
}
