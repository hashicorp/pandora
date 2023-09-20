// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedAccessGroupAssignmentScheduleModel
{
    [JsonPropertyName("accessId")]
    public PrivilegedAccessGroupAssignmentScheduleAccessIdConstant? AccessId { get; set; }

    [JsonPropertyName("activatedUsing")]
    public PrivilegedAccessGroupEligibilityScheduleModel? ActivatedUsing { get; set; }

    [JsonPropertyName("assignmentType")]
    public PrivilegedAccessGroupAssignmentScheduleAssignmentTypeConstant? AssignmentType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("createdUsing")]
    public string? CreatedUsing { get; set; }

    [JsonPropertyName("group")]
    public GroupModel? Group { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("memberType")]
    public PrivilegedAccessGroupAssignmentScheduleMemberTypeConstant? MemberType { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principal")]
    public DirectoryObjectModel? Principal { get; set; }

    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("scheduleInfo")]
    public RequestScheduleModel? ScheduleInfo { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
