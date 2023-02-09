using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;


internal class CachePropertiesModel
{
    [JsonPropertyName("cacheSizeGB")]
    public int? CacheSizeGB { get; set; }

    [JsonPropertyName("directoryServicesSettings")]
    public CacheDirectorySettingsModel? DirectoryServicesSettings { get; set; }

    [JsonPropertyName("encryptionSettings")]
    public CacheEncryptionSettingsModel? EncryptionSettings { get; set; }

    [JsonPropertyName("health")]
    public CacheHealthModel? Health { get; set; }

    [JsonPropertyName("mountAddresses")]
    public List<string>? MountAddresses { get; set; }

    [JsonPropertyName("networkSettings")]
    public CacheNetworkSettingsModel? NetworkSettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateTypeConstant? ProvisioningState { get; set; }

    [JsonPropertyName("securitySettings")]
    public CacheSecuritySettingsModel? SecuritySettings { get; set; }

    [JsonPropertyName("subnet")]
    public string? Subnet { get; set; }

    [JsonPropertyName("upgradeStatus")]
    public CacheUpgradeStatusModel? UpgradeStatus { get; set; }
}
