using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectedItems;

[ValueForType("AzureVmWorkloadProtectedItem")]
internal class AzureVMWorkloadProtectedItemModel : ProtectedItemModel
{
    [JsonPropertyName("extendedInfo")]
    public AzureVMWorkloadProtectedItemExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("kpisHealths")]
    public Dictionary<string, KPIResourceHealthDetailsModel>? KpisHealths { get; set; }

    [JsonPropertyName("lastBackupErrorDetail")]
    public ErrorDetailModel? LastBackupErrorDetail { get; set; }

    [JsonPropertyName("lastBackupStatus")]
    public LastBackupStatusConstant? LastBackupStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastBackupTime")]
    public DateTime? LastBackupTime { get; set; }

    [JsonPropertyName("parentName")]
    public string? ParentName { get; set; }

    [JsonPropertyName("parentType")]
    public string? ParentType { get; set; }

    [JsonPropertyName("protectedItemDataSourceId")]
    public string? ProtectedItemDataSourceId { get; set; }

    [JsonPropertyName("protectedItemHealthStatus")]
    public ProtectedItemHealthStatusConstant? ProtectedItemHealthStatus { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectionStateConstant? ProtectionState { get; set; }

    [JsonPropertyName("protectionStatus")]
    public string? ProtectionStatus { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }
}
