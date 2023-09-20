// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleAssignmentScheduleInstanceModel
{
    [JsonPropertyName("activatedUsing")]
    public UnifiedRoleEligibilityScheduleInstanceModel? ActivatedUsing { get; set; }

    [JsonPropertyName("appScope")]
    public AppScopeModel? AppScope { get; set; }

    [JsonPropertyName("appScopeId")]
    public string? AppScopeId { get; set; }

    [JsonPropertyName("assignmentType")]
    public string? AssignmentType { get; set; }

    [JsonPropertyName("directoryScope")]
    public DirectoryObjectModel? DirectoryScope { get; set; }

    [JsonPropertyName("directoryScopeId")]
    public string? DirectoryScopeId { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("memberType")]
    public string? MemberType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principal")]
    public DirectoryObjectModel? Principal { get; set; }

    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("roleAssignmentOriginId")]
    public string? RoleAssignmentOriginId { get; set; }

    [JsonPropertyName("roleAssignmentScheduleId")]
    public string? RoleAssignmentScheduleId { get; set; }

    [JsonPropertyName("roleDefinition")]
    public UnifiedRoleDefinitionModel? RoleDefinition { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
