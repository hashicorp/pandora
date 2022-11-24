using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationPolicies;

[ValueForType("HyperVReplicaAzure")]
internal class HyperVReplicaAzurePolicyDetailsModel : PolicyProviderSpecificDetailsModel
{
    [JsonPropertyName("activeStorageAccountId")]
    public string? ActiveStorageAccountId { get; set; }

    [JsonPropertyName("applicationConsistentSnapshotFrequencyInHours")]
    public int? ApplicationConsistentSnapshotFrequencyInHours { get; set; }

    [JsonPropertyName("encryption")]
    public string? Encryption { get; set; }

    [JsonPropertyName("onlineReplicationStartTime")]
    public string? OnlineReplicationStartTime { get; set; }

    [JsonPropertyName("recoveryPointHistoryDurationInHours")]
    public int? RecoveryPointHistoryDurationInHours { get; set; }

    [JsonPropertyName("replicationInterval")]
    public int? ReplicationInterval { get; set; }
}
