using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;

[ValueForType("HyperVReplica2012")]
internal class HyperVReplicaReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("initialReplicationDetails")]
    public InitialReplicationDetailsModel? InitialReplicationDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastReplicatedTime")]
    public DateTime? LastReplicatedTime { get; set; }

    [JsonPropertyName("vMDiskDetails")]
    public List<DiskDetailsModel>? VMDiskDetails { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMNicDetailsModel>? VMNics { get; set; }

    [JsonPropertyName("vmProtectionState")]
    public string? VMProtectionState { get; set; }

    [JsonPropertyName("vmProtectionStateDescription")]
    public string? VMProtectionStateDescription { get; set; }
}
