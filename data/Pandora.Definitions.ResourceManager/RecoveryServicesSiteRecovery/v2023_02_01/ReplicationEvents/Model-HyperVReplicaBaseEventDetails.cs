using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationEvents;

[ValueForType("HyperVReplicaBaseEventDetails")]
internal class HyperVReplicaBaseEventDetailsModel : EventProviderSpecificDetailsModel
{
    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("fabricName")]
    public string? FabricName { get; set; }

    [JsonPropertyName("remoteContainerName")]
    public string? RemoteContainerName { get; set; }

    [JsonPropertyName("remoteFabricName")]
    public string? RemoteFabricName { get; set; }
}
