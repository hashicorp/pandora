using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.SyncGroups;


internal class SyncGroupPropertiesModel
{
    [JsonPropertyName("conflictLoggingRetentionInDays")]
    public int? ConflictLoggingRetentionInDays { get; set; }

    [JsonPropertyName("conflictResolutionPolicy")]
    public SyncConflictResolutionPolicyConstant? ConflictResolutionPolicy { get; set; }

    [JsonPropertyName("enableConflictLogging")]
    public bool? EnableConflictLogging { get; set; }

    [JsonPropertyName("hubDatabasePassword")]
    public string? HubDatabasePassword { get; set; }

    [JsonPropertyName("hubDatabaseUserName")]
    public string? HubDatabaseUserName { get; set; }

    [JsonPropertyName("interval")]
    public int? Interval { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSyncTime")]
    public DateTime? LastSyncTime { get; set; }

    [JsonPropertyName("privateEndpointName")]
    public string? PrivateEndpointName { get; set; }

    [JsonPropertyName("schema")]
    public SyncGroupSchemaModel? Schema { get; set; }

    [JsonPropertyName("syncDatabaseId")]
    public string? SyncDatabaseId { get; set; }

    [JsonPropertyName("syncState")]
    public SyncGroupStateConstant? SyncState { get; set; }

    [JsonPropertyName("usePrivateLinkConnection")]
    public bool? UsePrivateLinkConnection { get; set; }
}
