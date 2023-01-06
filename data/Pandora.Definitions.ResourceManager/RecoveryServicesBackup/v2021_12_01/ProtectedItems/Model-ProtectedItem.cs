using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectedItems;


internal abstract class ProtectedItemModel
{
    [JsonPropertyName("backupManagementType")]
    public BackupManagementTypeConstant? BackupManagementType { get; set; }

    [JsonPropertyName("backupSetName")]
    public string? BackupSetName { get; set; }

    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("createMode")]
    public CreateModeConstant? CreateMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deferredDeleteTimeInUTC")]
    public DateTime? DeferredDeleteTimeInUTC { get; set; }

    [JsonPropertyName("deferredDeleteTimeRemaining")]
    public string? DeferredDeleteTimeRemaining { get; set; }

    [JsonPropertyName("isArchiveEnabled")]
    public bool? IsArchiveEnabled { get; set; }

    [JsonPropertyName("isDeferredDeleteScheduleUpcoming")]
    public bool? IsDeferredDeleteScheduleUpcoming { get; set; }

    [JsonPropertyName("isRehydrate")]
    public bool? IsRehydrate { get; set; }

    [JsonPropertyName("isScheduledForDeferredDelete")]
    public bool? IsScheduledForDeferredDelete { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRecoveryPoint")]
    public DateTime? LastRecoveryPoint { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("protectedItemType")]
    [ProvidesTypeHint]
    [Required]
    public string ProtectedItemType { get; set; }

    [JsonPropertyName("resourceGuardOperationRequests")]
    public List<string>? ResourceGuardOperationRequests { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("workloadType")]
    public DataSourceTypeConstant? WorkloadType { get; set; }
}
