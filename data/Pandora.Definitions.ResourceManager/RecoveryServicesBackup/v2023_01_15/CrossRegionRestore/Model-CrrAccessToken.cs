using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.CrossRegionRestore;


internal abstract class CrrAccessTokenModel
{
    [JsonPropertyName("accessTokenString")]
    public string? AccessTokenString { get; set; }

    [JsonPropertyName("bMSActiveRegion")]
    public string? BMSActiveRegion { get; set; }

    [JsonPropertyName("backupManagementType")]
    public string? BackupManagementType { get; set; }

    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("containerType")]
    public string? ContainerType { get; set; }

    [JsonPropertyName("coordinatorServiceStampId")]
    public string? CoordinatorServiceStampId { get; set; }

    [JsonPropertyName("coordinatorServiceStampUri")]
    public string? CoordinatorServiceStampUri { get; set; }

    [JsonPropertyName("datasourceContainerName")]
    public string? DatasourceContainerName { get; set; }

    [JsonPropertyName("datasourceId")]
    public string? DatasourceId { get; set; }

    [JsonPropertyName("datasourceName")]
    public string? DatasourceName { get; set; }

    [JsonPropertyName("datasourceType")]
    public string? DatasourceType { get; set; }

    [JsonPropertyName("objectType")]
    [ProvidesTypeHint]
    [Required]
    public string ObjectType { get; set; }

    [JsonPropertyName("protectionContainerId")]
    public int? ProtectionContainerId { get; set; }

    [JsonPropertyName("protectionServiceStampId")]
    public string? ProtectionServiceStampId { get; set; }

    [JsonPropertyName("protectionServiceStampUri")]
    public string? ProtectionServiceStampUri { get; set; }

    [JsonPropertyName("recoveryPointId")]
    public string? RecoveryPointId { get; set; }

    [JsonPropertyName("recoveryPointTime")]
    public string? RecoveryPointTime { get; set; }

    [JsonPropertyName("resourceGroupName")]
    public string? ResourceGroupName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    [JsonPropertyName("rpIsManagedVirtualMachine")]
    public bool? RpIsManagedVirtualMachine { get; set; }

    [JsonPropertyName("rpOriginalSAOption")]
    public bool? RpOriginalSAOption { get; set; }

    [JsonPropertyName("rpTierInformation")]
    public Dictionary<string, string>? RpTierInformation { get; set; }

    [JsonPropertyName("rpVMSizeDescription")]
    public string? RpVMSizeDescription { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("tokenExtendedInformation")]
    public string? TokenExtendedInformation { get; set; }
}
