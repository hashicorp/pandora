using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationFabrics;


internal class FailoverProcessServerRequestPropertiesModel
{
    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("sourceProcessServerId")]
    public string? SourceProcessServerId { get; set; }

    [JsonPropertyName("targetProcessServerId")]
    public string? TargetProcessServerId { get; set; }

    [JsonPropertyName("updateType")]
    public string? UpdateType { get; set; }

    [JsonPropertyName("vmsToMigrate")]
    public List<string>? VMsToMigrate { get; set; }
}
