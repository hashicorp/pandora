using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class SqlVirtualMachinePropertiesModel
{
    [JsonPropertyName("assessmentSettings")]
    public AssessmentSettingsModel? AssessmentSettings { get; set; }

    [JsonPropertyName("autoBackupSettings")]
    public AutoBackupSettingsModel? AutoBackupSettings { get; set; }

    [JsonPropertyName("autoPatchingSettings")]
    public AutoPatchingSettingsModel? AutoPatchingSettings { get; set; }

    [JsonPropertyName("keyVaultCredentialSettings")]
    public KeyVaultCredentialSettingsModel? KeyVaultCredentialSettings { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("serverConfigurationsManagementSettings")]
    public ServerConfigurationsManagementSettingsModel? ServerConfigurationsManagementSettings { get; set; }

    [JsonPropertyName("sqlImageOffer")]
    public string? SqlImageOffer { get; set; }

    [JsonPropertyName("sqlImageSku")]
    public SqlImageSkuConstant? SqlImageSku { get; set; }

    [JsonPropertyName("sqlManagement")]
    public SqlManagementModeConstant? SqlManagement { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public SqlServerLicenseTypeConstant? SqlServerLicenseType { get; set; }

    [JsonPropertyName("sqlVirtualMachineGroupResourceId")]
    public string? SqlVirtualMachineGroupResourceId { get; set; }

    [JsonPropertyName("storageConfigurationSettings")]
    public StorageConfigurationSettingsModel? StorageConfigurationSettings { get; set; }

    [JsonPropertyName("virtualMachineResourceId")]
    public string? VirtualMachineResourceId { get; set; }

    [JsonPropertyName("wsfcDomainCredentials")]
    public WsfcDomainCredentialsModel? WsfcDomainCredentials { get; set; }

    [JsonPropertyName("wsfcStaticIp")]
    public string? WsfcStaticIP { get; set; }
}
