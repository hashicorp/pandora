using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncMembers;


internal class SyncMemberPropertiesModel
{
    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("databaseType")]
    public SyncMemberDbTypeConstant? DatabaseType { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("privateEndpointName")]
    public string? PrivateEndpointName { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("sqlServerDatabaseId")]
    public string? SqlServerDatabaseId { get; set; }

    [JsonPropertyName("syncAgentId")]
    public string? SyncAgentId { get; set; }

    [JsonPropertyName("syncDirection")]
    public SyncDirectionConstant? SyncDirection { get; set; }

    [JsonPropertyName("syncMemberAzureDatabaseResourceId")]
    public string? SyncMemberAzureDatabaseResourceId { get; set; }

    [JsonPropertyName("syncState")]
    public SyncMemberStateConstant? SyncState { get; set; }

    [JsonPropertyName("usePrivateLinkConnection")]
    public bool? UsePrivateLinkConnection { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
