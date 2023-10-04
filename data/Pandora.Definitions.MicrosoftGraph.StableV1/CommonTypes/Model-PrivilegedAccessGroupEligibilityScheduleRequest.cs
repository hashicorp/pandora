// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PrivilegedAccessGroupEligibilityScheduleRequestModel
{
    [JsonPropertyName("accessId")]
    public PrivilegedAccessGroupEligibilityScheduleRequestAccessIdConstant? AccessId { get; set; }

    [JsonPropertyName("action")]
    public PrivilegedAccessGroupEligibilityScheduleRequestActionConstant? Action { get; set; }

    [JsonPropertyName("approvalId")]
    public string? ApprovalId { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customData")]
    public string? CustomData { get; set; }

    [JsonPropertyName("group")]
    public GroupModel? Group { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isValidationOnly")]
    public bool? IsValidationOnly { get; set; }

    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

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

    [JsonPropertyName("targetSchedule")]
    public PrivilegedAccessGroupEligibilityScheduleModel? TargetSchedule { get; set; }

    [JsonPropertyName("targetScheduleId")]
    public string? TargetScheduleId { get; set; }

    [JsonPropertyName("ticketInfo")]
    public TicketInfoModel? TicketInfo { get; set; }
}
