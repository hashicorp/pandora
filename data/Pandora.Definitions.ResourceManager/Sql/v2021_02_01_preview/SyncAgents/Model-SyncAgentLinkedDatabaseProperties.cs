using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SyncAgents;


internal class SyncAgentLinkedDatabasePropertiesModel
{
    [JsonPropertyName("databaseId")]
    public string? DatabaseId { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("databaseType")]
    public SyncMemberDbTypeConstant? DatabaseType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
