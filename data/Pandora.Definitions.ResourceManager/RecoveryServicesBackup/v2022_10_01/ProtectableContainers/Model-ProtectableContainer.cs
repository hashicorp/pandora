using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.ProtectableContainers;


internal abstract class ProtectableContainerModel
{
    [JsonPropertyName("backupManagementType")]
    public BackupManagementTypeConstant? BackupManagementType { get; set; }

    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthStatus")]
    public string? HealthStatus { get; set; }

    [JsonPropertyName("protectableContainerType")]
    [ProvidesTypeHint]
    [Required]
    public ProtectableContainerTypeConstant ProtectableContainerType { get; set; }
}
