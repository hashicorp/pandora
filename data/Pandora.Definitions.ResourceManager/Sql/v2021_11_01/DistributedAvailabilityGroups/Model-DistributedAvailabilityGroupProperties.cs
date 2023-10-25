using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DistributedAvailabilityGroups;


internal class DistributedAvailabilityGroupPropertiesModel
{
    [JsonPropertyName("distributedAvailabilityGroupId")]
    public string? DistributedAvailabilityGroupId { get; set; }

    [JsonPropertyName("lastHardenedLsn")]
    public string? LastHardenedLsn { get; set; }

    [JsonPropertyName("linkState")]
    public string? LinkState { get; set; }

    [JsonPropertyName("primaryAvailabilityGroupName")]
    public string? PrimaryAvailabilityGroupName { get; set; }

    [JsonPropertyName("replicationMode")]
    public ReplicationModeConstant? ReplicationMode { get; set; }

    [JsonPropertyName("secondaryAvailabilityGroupName")]
    public string? SecondaryAvailabilityGroupName { get; set; }

    [JsonPropertyName("sourceEndpoint")]
    public string? SourceEndpoint { get; set; }

    [JsonPropertyName("sourceReplicaId")]
    public string? SourceReplicaId { get; set; }

    [JsonPropertyName("targetDatabase")]
    public string? TargetDatabase { get; set; }

    [JsonPropertyName("targetReplicaId")]
    public string? TargetReplicaId { get; set; }
}
