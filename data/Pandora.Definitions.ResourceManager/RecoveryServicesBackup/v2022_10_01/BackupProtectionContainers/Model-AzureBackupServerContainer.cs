using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.BackupProtectionContainers;

[ValueForType("AzureBackupServerContainer")]
internal class AzureBackupServerContainerModel : ProtectionContainerModel
{
    [JsonPropertyName("canReRegister")]
    public bool? CanReRegister { get; set; }

    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }

    [JsonPropertyName("dpmAgentVersion")]
    public string? DpmAgentVersion { get; set; }

    [JsonPropertyName("dpmServers")]
    public List<string>? DpmServers { get; set; }

    [JsonPropertyName("extendedInfo")]
    public DPMContainerExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("protectionStatus")]
    public string? ProtectionStatus { get; set; }

    [JsonPropertyName("upgradeAvailable")]
    public bool? UpgradeAvailable { get; set; }
}
