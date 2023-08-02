// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RbacApplicationModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceNamespaces")]
    public List<UnifiedRbacResourceNamespaceModel>? ResourceNamespaces { get; set; }

    [JsonPropertyName("roleAssignmentApprovals")]
    public List<ApprovalModel>? RoleAssignmentApprovals { get; set; }

    [JsonPropertyName("roleAssignmentScheduleInstances")]
    public List<UnifiedRoleAssignmentScheduleInstanceModel>? RoleAssignmentScheduleInstances { get; set; }

    [JsonPropertyName("roleAssignmentScheduleRequests")]
    public List<UnifiedRoleAssignmentScheduleRequestModel>? RoleAssignmentScheduleRequests { get; set; }

    [JsonPropertyName("roleAssignmentSchedules")]
    public List<UnifiedRoleAssignmentScheduleModel>? RoleAssignmentSchedules { get; set; }

    [JsonPropertyName("roleAssignments")]
    public List<UnifiedRoleAssignmentModel>? RoleAssignments { get; set; }

    [JsonPropertyName("roleDefinitions")]
    public List<UnifiedRoleDefinitionModel>? RoleDefinitions { get; set; }

    [JsonPropertyName("roleEligibilityScheduleInstances")]
    public List<UnifiedRoleEligibilityScheduleInstanceModel>? RoleEligibilityScheduleInstances { get; set; }

    [JsonPropertyName("roleEligibilityScheduleRequests")]
    public List<UnifiedRoleEligibilityScheduleRequestModel>? RoleEligibilityScheduleRequests { get; set; }

    [JsonPropertyName("roleEligibilitySchedules")]
    public List<UnifiedRoleEligibilityScheduleModel>? RoleEligibilitySchedules { get; set; }

    [JsonPropertyName("transitiveRoleAssignments")]
    public List<UnifiedRoleAssignmentModel>? TransitiveRoleAssignments { get; set; }
}
