// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PrivilegedAccessGroupModel
{
    [JsonPropertyName("assignmentApprovals")]
    public List<ApprovalModel>? AssignmentApprovals { get; set; }

    [JsonPropertyName("assignmentScheduleInstances")]
    public List<PrivilegedAccessGroupAssignmentScheduleInstanceModel>? AssignmentScheduleInstances { get; set; }

    [JsonPropertyName("assignmentScheduleRequests")]
    public List<PrivilegedAccessGroupAssignmentScheduleRequestModel>? AssignmentScheduleRequests { get; set; }

    [JsonPropertyName("assignmentSchedules")]
    public List<PrivilegedAccessGroupAssignmentScheduleModel>? AssignmentSchedules { get; set; }

    [JsonPropertyName("eligibilityScheduleInstances")]
    public List<PrivilegedAccessGroupEligibilityScheduleInstanceModel>? EligibilityScheduleInstances { get; set; }

    [JsonPropertyName("eligibilityScheduleRequests")]
    public List<PrivilegedAccessGroupEligibilityScheduleRequestModel>? EligibilityScheduleRequests { get; set; }

    [JsonPropertyName("eligibilitySchedules")]
    public List<PrivilegedAccessGroupEligibilityScheduleModel>? EligibilitySchedules { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
