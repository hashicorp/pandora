// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleScheduleInstanceBaseModel
{
    [JsonPropertyName("appScope")]
    public AppScopeModel? AppScope { get; set; }

    [JsonPropertyName("appScopeId")]
    public string? AppScopeId { get; set; }

    [JsonPropertyName("directoryScope")]
    public DirectoryObjectModel? DirectoryScope { get; set; }

    [JsonPropertyName("directoryScopeId")]
    public string? DirectoryScopeId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principal")]
    public DirectoryObjectModel? Principal { get; set; }

    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("roleDefinition")]
    public UnifiedRoleDefinitionModel? RoleDefinition { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }
}
