using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ValidateOperation;

[ValueForType("AzureWorkloadSQLRestoreRequest")]
internal class AzureWorkloadSQLRestoreRequestModel : RestoreRequestModel
{
    [JsonPropertyName("alternateDirectoryPaths")]
    public List<SQLDataDirectoryMappingModel>? AlternateDirectoryPaths { get; set; }

    [JsonPropertyName("isNonRecoverable")]
    public bool? IsNonRecoverable { get; set; }

    [JsonPropertyName("propertyBag")]
    public Dictionary<string, string>? PropertyBag { get; set; }

    [JsonPropertyName("recoveryMode")]
    public RecoveryModeConstant? RecoveryMode { get; set; }

    [JsonPropertyName("recoveryType")]
    public RecoveryTypeConstant? RecoveryType { get; set; }

    [JsonPropertyName("shouldUseAlternateTargetLocation")]
    public bool? ShouldUseAlternateTargetLocation { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("targetInfo")]
    public TargetRestoreInfoModel? TargetInfo { get; set; }

    [JsonPropertyName("targetVirtualMachineId")]
    public string? TargetVirtualMachineId { get; set; }
}
