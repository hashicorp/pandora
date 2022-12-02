using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.BackupEngines;


internal abstract class BackupEngineBaseModel
{
    [JsonPropertyName("azureBackupAgentVersion")]
    public string? AzureBackupAgentVersion { get; set; }

    [JsonPropertyName("backupEngineId")]
    public string? BackupEngineId { get; set; }

    [JsonPropertyName("backupEngineState")]
    public string? BackupEngineState { get; set; }

    [JsonPropertyName("backupEngineType")]
    [ProvidesTypeHint]
    [Required]
    public BackupEngineTypeConstant BackupEngineType { get; set; }

    [JsonPropertyName("backupManagementType")]
    public BackupManagementTypeConstant? BackupManagementType { get; set; }

    [JsonPropertyName("canReRegister")]
    public bool? CanReRegister { get; set; }

    [JsonPropertyName("dpmVersion")]
    public string? DpmVersion { get; set; }

    [JsonPropertyName("extendedInfo")]
    public BackupEngineExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthStatus")]
    public string? HealthStatus { get; set; }

    [JsonPropertyName("isAzureBackupAgentUpgradeAvailable")]
    public bool? IsAzureBackupAgentUpgradeAvailable { get; set; }

    [JsonPropertyName("isDpmUpgradeAvailable")]
    public bool? IsDpmUpgradeAvailable { get; set; }

    [JsonPropertyName("registrationStatus")]
    public string? RegistrationStatus { get; set; }
}
