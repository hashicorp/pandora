// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedApprovalModel
{
    [JsonPropertyName("approvalDuration")]
    public string? ApprovalDuration { get; set; }

    [JsonPropertyName("approvalState")]
    public ApprovalStateConstant? ApprovalState { get; set; }

    [JsonPropertyName("approvalType")]
    public string? ApprovalType { get; set; }

    [JsonPropertyName("approverReason")]
    public string? ApproverReason { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("request")]
    public PrivilegedRoleAssignmentRequestModel? Request { get; set; }

    [JsonPropertyName("requestorReason")]
    public string? RequestorReason { get; set; }

    [JsonPropertyName("roleId")]
    public string? RoleId { get; set; }

    [JsonPropertyName("roleInfo")]
    public PrivilegedRoleModel? RoleInfo { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
