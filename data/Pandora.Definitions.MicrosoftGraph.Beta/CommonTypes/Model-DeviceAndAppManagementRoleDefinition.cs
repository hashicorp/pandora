// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceAndAppManagementRoleDefinitionModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isBuiltIn")]
    public bool? IsBuiltIn { get; set; }

    [JsonPropertyName("isBuiltInRoleDefinition")]
    public bool? IsBuiltInRoleDefinition { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissions")]
    public List<RolePermissionModel>? Permissions { get; set; }

    [JsonPropertyName("roleAssignments")]
    public List<RoleAssignmentModel>? RoleAssignments { get; set; }

    [JsonPropertyName("rolePermissions")]
    public List<RolePermissionModel>? RolePermissions { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }
}
