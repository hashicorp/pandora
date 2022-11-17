using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationPolicies;

[ValueForType("HyperVReplicaBasePolicyDetails")]
internal class HyperVReplicaBasePolicyDetailsModel : PolicyProviderSpecificDetailsModel
{
    [JsonPropertyName("allowedAuthenticationType")]
    public int? AllowedAuthenticationType { get; set; }

    [JsonPropertyName("applicationConsistentSnapshotFrequencyInHours")]
    public int? ApplicationConsistentSnapshotFrequencyInHours { get; set; }

    [JsonPropertyName("compression")]
    public string? Compression { get; set; }

    [JsonPropertyName("initialReplicationMethod")]
    public string? InitialReplicationMethod { get; set; }

    [JsonPropertyName("offlineReplicationExportPath")]
    public string? OfflineReplicationExportPath { get; set; }

    [JsonPropertyName("offlineReplicationImportPath")]
    public string? OfflineReplicationImportPath { get; set; }

    [JsonPropertyName("onlineReplicationStartTime")]
    public string? OnlineReplicationStartTime { get; set; }

    [JsonPropertyName("recoveryPoints")]
    public int? RecoveryPoints { get; set; }

    [JsonPropertyName("replicaDeletionOption")]
    public string? ReplicaDeletionOption { get; set; }

    [JsonPropertyName("replicationPort")]
    public int? ReplicationPort { get; set; }
}
