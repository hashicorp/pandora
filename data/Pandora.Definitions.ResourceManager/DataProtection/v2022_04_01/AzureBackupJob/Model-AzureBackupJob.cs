using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.AzureBackupJob;


internal class AzureBackupJobModel
{
    [JsonPropertyName("activityID")]
    [Required]
    public string ActivityID { get; set; }

    [JsonPropertyName("backupInstanceFriendlyName")]
    [Required]
    public string BackupInstanceFriendlyName { get; set; }

    [JsonPropertyName("backupInstanceId")]
    public string? BackupInstanceId { get; set; }

    [JsonPropertyName("dataSourceId")]
    [Required]
    public string DataSourceId { get; set; }

    [JsonPropertyName("dataSourceLocation")]
    [Required]
    public string DataSourceLocation { get; set; }

    [JsonPropertyName("dataSourceName")]
    [Required]
    public string DataSourceName { get; set; }

    [JsonPropertyName("dataSourceSetName")]
    public string? DataSourceSetName { get; set; }

    [JsonPropertyName("dataSourceType")]
    [Required]
    public string DataSourceType { get; set; }

    [JsonPropertyName("destinationDataStoreName")]
    public string? DestinationDataStoreName { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<UserFacingErrorModel>? ErrorDetails { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("extendedInfo")]
    public JobExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("isUserTriggered")]
    [Required]
    public bool IsUserTriggered { get; set; }

    [JsonPropertyName("operation")]
    [Required]
    public string Operation { get; set; }

    [JsonPropertyName("operationCategory")]
    [Required]
    public string OperationCategory { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("progressEnabled")]
    [Required]
    public bool ProgressEnabled { get; set; }

    [JsonPropertyName("progressUrl")]
    public string? ProgressUrl { get; set; }

    [JsonPropertyName("restoreType")]
    public string? RestoreType { get; set; }

    [JsonPropertyName("sourceDataStoreName")]
    public string? SourceDataStoreName { get; set; }

    [JsonPropertyName("sourceResourceGroup")]
    [Required]
    public string SourceResourceGroup { get; set; }

    [JsonPropertyName("sourceSubscriptionID")]
    [Required]
    public string SourceSubscriptionID { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    [Required]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public string Status { get; set; }

    [JsonPropertyName("subscriptionId")]
    [Required]
    public string SubscriptionId { get; set; }

    [JsonPropertyName("supportedActions")]
    [Required]
    public List<string> SupportedActions { get; set; }

    [JsonPropertyName("vaultName")]
    [Required]
    public string VaultName { get; set; }
}
