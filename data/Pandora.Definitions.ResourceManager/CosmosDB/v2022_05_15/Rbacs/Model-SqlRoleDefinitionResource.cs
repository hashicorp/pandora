using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.Rbacs;


internal class SqlRoleDefinitionResourceModel
{
    [JsonPropertyName("assignableScopes")]
    public List<string>? AssignableScopes { get; set; }

    [JsonPropertyName("permissions")]
    public List<PermissionModel>? Permissions { get; set; }

    [JsonPropertyName("roleName")]
    public string? RoleName { get; set; }

    [JsonPropertyName("type")]
    public RoleDefinitionTypeConstant? Type { get; set; }
}
