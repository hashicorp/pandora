using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabases;


internal class ManagedDatabasePropertiesModel
{
    [JsonPropertyName("autoCompleteRestore")]
    public bool? AutoCompleteRestore { get; set; }

    [JsonPropertyName("catalogCollation")]
    public CatalogCollationTypeConstant? CatalogCollation { get; set; }

    [JsonPropertyName("collation")]
    public string? Collation { get; set; }

    [JsonPropertyName("createMode")]
    public ManagedDatabaseCreateModeConstant? CreateMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("crossSubscriptionRestorableDroppedDatabaseId")]
    public string? CrossSubscriptionRestorableDroppedDatabaseId { get; set; }

    [JsonPropertyName("crossSubscriptionSourceDatabaseId")]
    public string? CrossSubscriptionSourceDatabaseId { get; set; }

    [JsonPropertyName("crossSubscriptionTargetManagedInstanceId")]
    public string? CrossSubscriptionTargetManagedInstanceId { get; set; }

    [JsonPropertyName("defaultSecondaryLocation")]
    public string? DefaultSecondaryLocation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("earliestRestorePoint")]
    public DateTime? EarliestRestorePoint { get; set; }

    [JsonPropertyName("failoverGroupId")]
    public string? FailoverGroupId { get; set; }

    [JsonPropertyName("isLedgerOn")]
    public bool? IsLedgerOn { get; set; }

    [JsonPropertyName("lastBackupName")]
    public string? LastBackupName { get; set; }

    [JsonPropertyName("longTermRetentionBackupResourceId")]
    public string? LongTermRetentionBackupResourceId { get; set; }

    [JsonPropertyName("recoverableDatabaseId")]
    public string? RecoverableDatabaseId { get; set; }

    [JsonPropertyName("restorableDroppedDatabaseId")]
    public string? RestorableDroppedDatabaseId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restorePointInTime")]
    public DateTime? RestorePointInTime { get; set; }

    [JsonPropertyName("sourceDatabaseId")]
    public string? SourceDatabaseId { get; set; }

    [JsonPropertyName("status")]
    public ManagedDatabaseStatusConstant? Status { get; set; }

    [JsonPropertyName("storageContainerIdentity")]
    public string? StorageContainerIdentity { get; set; }

    [JsonPropertyName("storageContainerSasToken")]
    public string? StorageContainerSasToken { get; set; }

    [JsonPropertyName("storageContainerUri")]
    public string? StorageContainerUri { get; set; }
}
