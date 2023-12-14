using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;


internal class DbMigrationStatusModel
{
    [JsonPropertyName("appliedChanges")]
    public int? AppliedChanges { get; set; }

    [JsonPropertyName("cdcDeleteCounter")]
    public int? CdcDeleteCounter { get; set; }

    [JsonPropertyName("cdcInsertCounter")]
    public int? CdcInsertCounter { get; set; }

    [JsonPropertyName("cdcUpdateCounter")]
    public int? CdcUpdateCounter { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endedOn")]
    public DateTime? EndedOn { get; set; }

    [JsonPropertyName("fullLoadCompletedTables")]
    public int? FullLoadCompletedTables { get; set; }

    [JsonPropertyName("fullLoadErroredTables")]
    public int? FullLoadErroredTables { get; set; }

    [JsonPropertyName("fullLoadLoadingTables")]
    public int? FullLoadLoadingTables { get; set; }

    [JsonPropertyName("fullLoadQueuedTables")]
    public int? FullLoadQueuedTables { get; set; }

    [JsonPropertyName("incomingChanges")]
    public int? IncomingChanges { get; set; }

    [JsonPropertyName("latency")]
    public int? Latency { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("migrationOperation")]
    public string? MigrationOperation { get; set; }

    [JsonPropertyName("migrationState")]
    public MigrationDbStateConstant? MigrationState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startedOn")]
    public DateTime? StartedOn { get; set; }
}
