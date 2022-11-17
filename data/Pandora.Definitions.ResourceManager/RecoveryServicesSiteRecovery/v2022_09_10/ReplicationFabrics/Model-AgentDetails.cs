using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationFabrics;


internal class AgentDetailsModel
{
    [JsonPropertyName("agentId")]
    public string? AgentId { get; set; }

    [JsonPropertyName("biosId")]
    public string? BiosId { get; set; }

    [JsonPropertyName("disks")]
    public List<AgentDiskDetailsModel>? Disks { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("machineId")]
    public string? MachineId { get; set; }
}
