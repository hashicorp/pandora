using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.ValidateOperation;

[ValueForType("AzureWorkloadSQLPointInTimeRestoreRequest")]
internal class AzureWorkloadSQLPointInTimeRestoreRequestModel : RestoreRequestModel
{
    [JsonPropertyName("alternateDirectoryPaths")]
    public List<SQLDataDirectoryMappingModel>? AlternateDirectoryPaths { get; set; }

    [JsonPropertyName("isNonRecoverable")]
    public bool? IsNonRecoverable { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("pointInTime")]
    public DateTime? PointInTime { get; set; }

    [JsonPropertyName("propertyBag")]
    public Dictionary<string, string>? PropertyBag { get; set; }

    [JsonPropertyName("recoveryMode")]
    public RecoveryModeConstant? RecoveryMode { get; set; }

    [JsonPropertyName("recoveryType")]
    public RecoveryTypeConstant? RecoveryType { get; set; }

    [JsonPropertyName("shouldUseAlternateTargetLocation")]
    public bool? ShouldUseAlternateTargetLocation { get; set; }

    [JsonPropertyName("snapshotRestoreParameters")]
    public SnapshotRestoreParametersModel? SnapshotRestoreParameters { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("targetInfo")]
    public TargetRestoreInfoModel? TargetInfo { get; set; }

    [JsonPropertyName("targetResourceGroupName")]
    public string? TargetResourceGroupName { get; set; }

    [JsonPropertyName("targetVirtualMachineId")]
    public string? TargetVirtualMachineId { get; set; }

    [JsonPropertyName("userAssignedManagedIdentityDetails")]
    public UserAssignedManagedIdentityDetailsModel? UserAssignedManagedIdentityDetails { get; set; }
}
