using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.Databases;


internal class DatabasePropertiesModel
{
    [JsonPropertyName("catalogCollation")]
    public CatalogCollationTypeConstant? CatalogCollation { get; set; }

    [JsonPropertyName("collation")]
    public string? Collation { get; set; }

    [JsonPropertyName("createMode")]
    public CreateModeConstant? CreateMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("currentServiceObjectiveName")]
    public string? CurrentServiceObjectiveName { get; set; }

    [JsonPropertyName("databaseId")]
    public string? DatabaseId { get; set; }

    [JsonPropertyName("defaultSecondaryLocation")]
    public string? DefaultSecondaryLocation { get; set; }

    [JsonPropertyName("elasticPoolId")]
    public string? ElasticPoolId { get; set; }

    [JsonPropertyName("failoverGroupId")]
    public string? FailoverGroupId { get; set; }

    [JsonPropertyName("longTermRetentionBackupResourceId")]
    public string? LongTermRetentionBackupResourceId { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public int? MaxSizeBytes { get; set; }

    [JsonPropertyName("recoverableDatabaseId")]
    public string? RecoverableDatabaseId { get; set; }

    [JsonPropertyName("recoveryServicesRecoveryPointId")]
    public string? RecoveryServicesRecoveryPointId { get; set; }

    [JsonPropertyName("restorableDroppedDatabaseId")]
    public string? RestorableDroppedDatabaseId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restorePointInTime")]
    public DateTime? RestorePointInTime { get; set; }

    [JsonPropertyName("sampleName")]
    public SampleNameConstant? SampleName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sourceDatabaseDeletionDate")]
    public DateTime? SourceDatabaseDeletionDate { get; set; }

    [JsonPropertyName("sourceDatabaseId")]
    public string? SourceDatabaseId { get; set; }

    [JsonPropertyName("status")]
    public DatabaseStatusConstant? Status { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
