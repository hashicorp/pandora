// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GovernanceRoleAssignmentModel
{
    [JsonPropertyName("assignmentState")]
    public string? AssignmentState { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("linkedEligibleRoleAssignment")]
    public GovernanceRoleAssignmentModel? LinkedEligibleRoleAssignment { get; set; }

    [JsonPropertyName("linkedEligibleRoleAssignmentId")]
    public string? LinkedEligibleRoleAssignmentId { get; set; }

    [JsonPropertyName("memberType")]
    public string? MemberType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resource")]
    public GovernanceResourceModel? Resource { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("roleDefinition")]
    public GovernanceRoleDefinitionModel? RoleDefinition { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("subject")]
    public GovernanceSubjectModel? Subject { get; set; }

    [JsonPropertyName("subjectId")]
    public string? SubjectId { get; set; }
}
