using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.RecoveryPoints;

[ValueForType("IaasVMRecoveryPoint")]
internal class IaasVMRecoveryPointModel : RecoveryPointModel
{
    [JsonPropertyName("extendedLocation")]
    public ExtendedLocationModel? ExtendedLocation { get; set; }

    [JsonPropertyName("isInstantIlrSessionActive")]
    public bool? IsInstantIlrSessionActive { get; set; }

    [JsonPropertyName("isManagedVirtualMachine")]
    public bool? IsManagedVirtualMachine { get; set; }

    [JsonPropertyName("isPrivateAccessEnabledOnAnyDisk")]
    public bool? IsPrivateAccessEnabledOnAnyDisk { get; set; }

    [JsonPropertyName("isSourceVMEncrypted")]
    public bool? IsSourceVMEncrypted { get; set; }

    [JsonPropertyName("keyAndSecret")]
    public KeyAndSecretDetailsModel? KeyAndSecret { get; set; }

    [JsonPropertyName("originalStorageAccountOption")]
    public bool? OriginalStorageAccountOption { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("recoveryPointAdditionalInfo")]
    public string? RecoveryPointAdditionalInfo { get; set; }

    [JsonPropertyName("recoveryPointDiskConfiguration")]
    public RecoveryPointDiskConfigurationModel? RecoveryPointDiskConfiguration { get; set; }

    [JsonPropertyName("recoveryPointMoveReadinessInfo")]
    public Dictionary<string, RecoveryPointMoveReadinessInfoModel>? RecoveryPointMoveReadinessInfo { get; set; }

    [JsonPropertyName("recoveryPointProperties")]
    public RecoveryPointPropertiesModel? RecoveryPointProperties { get; set; }

    [JsonPropertyName("recoveryPointTierDetails")]
    public List<RecoveryPointTierInformationV2Model>? RecoveryPointTierDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("recoveryPointTime")]
    public DateTime? RecoveryPointTime { get; set; }

    [JsonPropertyName("recoveryPointType")]
    public string? RecoveryPointType { get; set; }

    [JsonPropertyName("securityType")]
    public string? SecurityType { get; set; }

    [JsonPropertyName("sourceVMStorageType")]
    public string? SourceVMStorageType { get; set; }

    [JsonPropertyName("virtualMachineSize")]
    public string? VirtualMachineSize { get; set; }

    [JsonPropertyName("zones")]
    public CustomTypes.Zones? Zones { get; set; }
}
