using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.SoftDeletedContainers;

[ValueForType("StorageContainer")]
internal class AzureStorageContainerModel : ProtectionContainerModel
{
    [JsonPropertyName("acquireStorageAccountLock")]
    public AcquireStorageAccountLockConstant? AcquireStorageAccountLock { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("storageAccountVersion")]
    public string? StorageAccountVersion { get; set; }
}
