using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Mongorbacs;


internal class MongoRoleDefinitionResourceModel
{
    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("privileges")]
    public List<PrivilegeModel>? Privileges { get; set; }

    [JsonPropertyName("roleName")]
    public string? RoleName { get; set; }

    [JsonPropertyName("roles")]
    public List<RoleModel>? Roles { get; set; }

    [JsonPropertyName("type")]
    public MongoRoleDefinitionTypeConstant? Type { get; set; }
}
