// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedRoleAssignmentRequestModel
{
    [JsonPropertyName("assignmentState")]
    public string? AssignmentState { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("requestedDateTime")]
    public DateTime? RequestedDateTime { get; set; }

    [JsonPropertyName("roleId")]
    public string? RoleId { get; set; }

    [JsonPropertyName("roleInfo")]
    public PrivilegedRoleModel? RoleInfo { get; set; }

    [JsonPropertyName("schedule")]
    public GovernanceScheduleModel? Schedule { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("ticketNumber")]
    public string? TicketNumber { get; set; }

    [JsonPropertyName("ticketSystem")]
    public string? TicketSystem { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
