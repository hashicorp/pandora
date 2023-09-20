// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleAssignmentMultipleModel
{
    [JsonPropertyName("appScopeIds")]
    public List<string>? AppScopeIds { get; set; }

    [JsonPropertyName("appScopes")]
    public List<AppScopeModel>? AppScopes { get; set; }

    [JsonPropertyName("condition")]
    public string? Condition { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("directoryScopeIds")]
    public List<string>? DirectoryScopeIds { get; set; }

    [JsonPropertyName("directoryScopes")]
    public List<DirectoryObjectModel>? DirectoryScopes { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principalIds")]
    public List<string>? PrincipalIds { get; set; }

    [JsonPropertyName("principals")]
    public List<DirectoryObjectModel>? Principals { get; set; }

    [JsonPropertyName("roleDefinition")]
    public UnifiedRoleDefinitionModel? RoleDefinition { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }
}
