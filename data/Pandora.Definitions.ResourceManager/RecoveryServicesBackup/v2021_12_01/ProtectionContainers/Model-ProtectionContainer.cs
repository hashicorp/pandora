using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectionContainers;


internal abstract class ProtectionContainerModel
{
    [JsonPropertyName("backupManagementType")]
    public BackupManagementTypeConstant? BackupManagementType { get; set; }

    [JsonPropertyName("containerType")]
    [ProvidesTypeHint]
    [Required]
    public ContainerTypeConstant ContainerType { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthStatus")]
    public string? HealthStatus { get; set; }

    [JsonPropertyName("protectableObjectType")]
    public string? ProtectableObjectType { get; set; }

    [JsonPropertyName("registrationStatus")]
    public string? RegistrationStatus { get; set; }
}
