using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Replicas;


internal class ReplicaModel
{
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    [JsonPropertyName("promoteMode")]
    public ReadReplicaPromoteModeConstant? PromoteMode { get; set; }

    [JsonPropertyName("promoteOption")]
    public ReplicationPromoteOptionConstant? PromoteOption { get; set; }

    [JsonPropertyName("replicationState")]
    public ReplicationStateConstant? ReplicationState { get; set; }

    [JsonPropertyName("role")]
    public ReplicationRoleConstant? Role { get; set; }
}
