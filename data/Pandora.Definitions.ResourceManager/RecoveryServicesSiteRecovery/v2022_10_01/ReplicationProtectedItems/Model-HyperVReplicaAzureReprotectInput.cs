using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("HyperVReplicaAzure")]
internal class HyperVReplicaAzureReprotectInputModel : ReverseReplicationProviderSpecificInputModel
{
    [JsonPropertyName("hvHostVmId")]
    public string? HvHostVmId { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("vHDId")]
    public string? VHDId { get; set; }

    [JsonPropertyName("vmName")]
    public string? VirtualMachineName { get; set; }
}
