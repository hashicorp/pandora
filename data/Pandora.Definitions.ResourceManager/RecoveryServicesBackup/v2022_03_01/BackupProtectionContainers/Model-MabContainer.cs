using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectionContainers;

[ValueForType("Windows")]
internal class MabContainerModel : ProtectionContainerModel
{
    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("canReRegister")]
    public bool? CanReRegister { get; set; }

    [JsonPropertyName("containerHealthState")]
    public string? ContainerHealthState { get; set; }

    [JsonPropertyName("containerId")]
    public int? ContainerId { get; set; }

    [JsonPropertyName("extendedInfo")]
    public MabContainerExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("mabContainerHealthDetails")]
    public List<MABContainerHealthDetailsModel>? MabContainerHealthDetails { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }
}
