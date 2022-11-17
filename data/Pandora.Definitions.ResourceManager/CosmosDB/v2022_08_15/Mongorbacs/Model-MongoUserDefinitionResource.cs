using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Mongorbacs;


internal class MongoUserDefinitionResourceModel
{
    [JsonPropertyName("customData")]
    public string? CustomData { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("mechanisms")]
    public string? Mechanisms { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("roles")]
    public List<RoleModel>? Roles { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
