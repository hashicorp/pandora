using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;


internal class DataBoxEdgeDeviceExtendedInfoPropertiesModel
{
    [JsonPropertyName("channelIntegrityKeyName")]
    public string? ChannelIntegrityKeyName { get; set; }

    [JsonPropertyName("channelIntegrityKeyVersion")]
    public string? ChannelIntegrityKeyVersion { get; set; }

    [JsonPropertyName("clientSecretStoreId")]
    public string? ClientSecretStoreId { get; set; }

    [JsonPropertyName("clientSecretStoreUrl")]
    public string? ClientSecretStoreUrl { get; set; }

    [JsonPropertyName("cloudWitnessContainerName")]
    public string? CloudWitnessContainerName { get; set; }

    [JsonPropertyName("cloudWitnessStorageAccountName")]
    public string? CloudWitnessStorageAccountName { get; set; }

    [JsonPropertyName("cloudWitnessStorageEndpoint")]
    public string? CloudWitnessStorageEndpoint { get; set; }

    [JsonPropertyName("clusterWitnessType")]
    public ClusterWitnessTypeConstant? ClusterWitnessType { get; set; }

    [JsonPropertyName("deviceSecrets")]
    public Dictionary<string, SecretModel>? DeviceSecrets { get; set; }

    [JsonPropertyName("encryptionKey")]
    public string? EncryptionKey { get; set; }

    [JsonPropertyName("encryptionKeyThumbprint")]
    public string? EncryptionKeyThumbprint { get; set; }

    [JsonPropertyName("fileShareWitnessLocation")]
    public string? FileShareWitnessLocation { get; set; }

    [JsonPropertyName("fileShareWitnessUsername")]
    public string? FileShareWitnessUsername { get; set; }

    [JsonPropertyName("keyVaultSyncStatus")]
    public KeyVaultSyncStatusConstant? KeyVaultSyncStatus { get; set; }

    [JsonPropertyName("resourceKey")]
    public string? ResourceKey { get; set; }
}
