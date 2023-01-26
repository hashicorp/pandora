using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Service;

[ValueForType("Stateful")]
internal class StatefulServicePropertiesModel : ServiceResourcePropertiesModel
{
    [JsonPropertyName("hasPersistedState")]
    public bool? HasPersistedState { get; set; }

    [JsonPropertyName("minReplicaSetSize")]
    public int? MinReplicaSetSize { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("quorumLossWaitDuration")]
    public DateTime? QuorumLossWaitDuration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("replicaRestartWaitDuration")]
    public DateTime? ReplicaRestartWaitDuration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("standByReplicaKeepDuration")]
    public DateTime? StandByReplicaKeepDuration { get; set; }

    [JsonPropertyName("targetReplicaSetSize")]
    public int? TargetReplicaSetSize { get; set; }
}
