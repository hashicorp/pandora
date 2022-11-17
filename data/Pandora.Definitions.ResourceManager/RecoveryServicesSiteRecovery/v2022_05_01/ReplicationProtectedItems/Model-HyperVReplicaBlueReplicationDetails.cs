using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("HyperVReplica2012R2")]
internal class HyperVReplicaBlueReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("initialReplicationDetails")]
    public InitialReplicationDetailsModel? InitialReplicationDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastReplicatedTime")]
    public DateTime? LastReplicatedTime { get; set; }

    [JsonPropertyName("vMDiskDetails")]
    public List<DiskDetailsModel>? VMDiskDetails { get; set; }

    [JsonPropertyName("vmId")]
    public string? VmId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMNicDetailsModel>? VmNics { get; set; }

    [JsonPropertyName("vmProtectionState")]
    public string? VmProtectionState { get; set; }

    [JsonPropertyName("vmProtectionStateDescription")]
    public string? VmProtectionStateDescription { get; set; }
}
