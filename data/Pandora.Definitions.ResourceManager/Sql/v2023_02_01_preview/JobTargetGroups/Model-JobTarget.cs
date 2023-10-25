using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.JobTargetGroups;


internal class JobTargetModel
{
    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("elasticPoolName")]
    public string? ElasticPoolName { get; set; }

    [JsonPropertyName("membershipType")]
    public JobTargetGroupMembershipTypeConstant? MembershipType { get; set; }

    [JsonPropertyName("refreshCredential")]
    public string? RefreshCredential { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("shardMapName")]
    public string? ShardMapName { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public JobTargetTypeConstant Type { get; set; }
}
