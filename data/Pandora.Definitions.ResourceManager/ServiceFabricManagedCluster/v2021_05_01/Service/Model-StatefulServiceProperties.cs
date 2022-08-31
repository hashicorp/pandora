using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Service;

[ValueForType("Stateful")]
internal class StatefulServicePropertiesModel : ServiceResourcePropertiesModel
{
    [JsonPropertyName("hasPersistedState")]
    public bool? HasPersistedState { get; set; }

    [JsonPropertyName("minReplicaSetSize")]
    public int? MinReplicaSetSize { get; set; }

    [JsonPropertyName("quorumLossWaitDuration")]
    public string? QuorumLossWaitDuration { get; set; }

    [JsonPropertyName("replicaRestartWaitDuration")]
    public string? ReplicaRestartWaitDuration { get; set; }

    [JsonPropertyName("servicePlacementTimeLimit")]
    public string? ServicePlacementTimeLimit { get; set; }

    [JsonPropertyName("standByReplicaKeepDuration")]
    public string? StandByReplicaKeepDuration { get; set; }

    [JsonPropertyName("targetReplicaSetSize")]
    public int? TargetReplicaSetSize { get; set; }
}
