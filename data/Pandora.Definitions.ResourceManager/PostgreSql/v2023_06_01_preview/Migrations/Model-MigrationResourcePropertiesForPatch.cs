using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;


internal class MigrationResourcePropertiesForPatchModel
{
    [JsonPropertyName("cancel")]
    public CancelEnumConstant? Cancel { get; set; }

    [JsonPropertyName("dbsToCancelMigrationOn")]
    public List<string>? DbsToCancelMigrationOn { get; set; }

    [MaxItems(50)]
    [JsonPropertyName("dbsToMigrate")]
    public List<string>? DbsToMigrate { get; set; }

    [JsonPropertyName("dbsToTriggerCutoverOn")]
    public List<string>? DbsToTriggerCutoverOn { get; set; }

    [JsonPropertyName("migrationMode")]
    public MigrationModeConstant? MigrationMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("migrationWindowStartTimeInUtc")]
    public DateTime? MigrationWindowStartTimeInUtc { get; set; }

    [JsonPropertyName("overwriteDbsInTarget")]
    public OverwriteDbsInTargetEnumConstant? OverwriteDbsInTarget { get; set; }

    [JsonPropertyName("secretParameters")]
    public MigrationSecretParametersModel? SecretParameters { get; set; }

    [JsonPropertyName("setupLogicalReplicationOnSourceDbIfNeeded")]
    public LogicalReplicationOnSourceDbEnumConstant? SetupLogicalReplicationOnSourceDbIfNeeded { get; set; }

    [JsonPropertyName("sourceDbServerFullyQualifiedDomainName")]
    public string? SourceDbServerFullyQualifiedDomainName { get; set; }

    [JsonPropertyName("sourceDbServerResourceId")]
    public string? SourceDbServerResourceId { get; set; }

    [JsonPropertyName("startDataMigration")]
    public StartDataMigrationEnumConstant? StartDataMigration { get; set; }

    [JsonPropertyName("targetDbServerFullyQualifiedDomainName")]
    public string? TargetDbServerFullyQualifiedDomainName { get; set; }

    [JsonPropertyName("triggerCutover")]
    public TriggerCutoverEnumConstant? TriggerCutover { get; set; }
}
