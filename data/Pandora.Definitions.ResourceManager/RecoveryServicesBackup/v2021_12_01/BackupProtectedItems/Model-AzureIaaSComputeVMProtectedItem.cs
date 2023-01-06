using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupProtectedItems;

[ValueForType("Microsoft.Compute/virtualMachines")]
internal class AzureIaaSComputeVMProtectedItemModel : ProtectedItemModel
{
    [JsonPropertyName("extendedInfo")]
    public AzureIaaSVMProtectedItemExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("extendedProperties")]
    public ExtendedPropertiesModel? ExtendedProperties { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthDetails")]
    public List<ResourceHealthDetailsModel>? HealthDetails { get; set; }

    [JsonPropertyName("healthStatus")]
    public HealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("kpisHealths")]
    public Dictionary<string, KPIResourceHealthDetailsModel>? KpisHealths { get; set; }

    [JsonPropertyName("lastBackupStatus")]
    public string? LastBackupStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastBackupTime")]
    public DateTime? LastBackupTime { get; set; }

    [JsonPropertyName("protectedItemDataId")]
    public string? ProtectedItemDataId { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectionStateConstant? ProtectionState { get; set; }

    [JsonPropertyName("protectionStatus")]
    public string? ProtectionStatus { get; set; }

    [JsonPropertyName("virtualMachineId")]
    public string? VirtualMachineId { get; set; }
}
