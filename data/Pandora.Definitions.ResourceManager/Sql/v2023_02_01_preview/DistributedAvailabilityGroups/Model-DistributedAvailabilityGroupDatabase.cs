using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DistributedAvailabilityGroups;


internal class DistributedAvailabilityGroupDatabaseModel
{
    [JsonPropertyName("connectedState")]
    public ReplicaConnectedStateConstant? ConnectedState { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("instanceRedoReplicationLagSeconds")]
    public int? InstanceRedoReplicationLagSeconds { get; set; }

    [JsonPropertyName("instanceReplicaId")]
    public string? InstanceReplicaId { get; set; }

    [JsonPropertyName("instanceSendReplicationLagSeconds")]
    public int? InstanceSendReplicationLagSeconds { get; set; }

    [JsonPropertyName("lastBackupLsn")]
    public string? LastBackupLsn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastBackupTime")]
    public DateTime? LastBackupTime { get; set; }

    [JsonPropertyName("lastCommitLsn")]
    public string? LastCommitLsn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCommitTime")]
    public DateTime? LastCommitTime { get; set; }

    [JsonPropertyName("lastHardenedLsn")]
    public string? LastHardenedLsn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHardenedTime")]
    public DateTime? LastHardenedTime { get; set; }

    [JsonPropertyName("lastReceivedLsn")]
    public string? LastReceivedLsn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastReceivedTime")]
    public DateTime? LastReceivedTime { get; set; }

    [JsonPropertyName("lastSentLsn")]
    public string? LastSentLsn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSentTime")]
    public DateTime? LastSentTime { get; set; }

    [JsonPropertyName("mostRecentLinkError")]
    public string? MostRecentLinkError { get; set; }

    [JsonPropertyName("partnerAuthCertValidity")]
    public CertificateInfoModel? PartnerAuthCertValidity { get; set; }

    [JsonPropertyName("partnerReplicaId")]
    public string? PartnerReplicaId { get; set; }

    [JsonPropertyName("replicaState")]
    public string? ReplicaState { get; set; }

    [JsonPropertyName("synchronizationHealth")]
    public ReplicaSynchronizationHealthConstant? SynchronizationHealth { get; set; }
}
