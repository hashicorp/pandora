// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SwapShiftsChangeRequestModel
{
    [JsonPropertyName("assignedTo")]
    public SwapShiftsChangeRequestAssignedToConstant? AssignedTo { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("managerActionDateTime")]
    public DateTime? ManagerActionDateTime { get; set; }

    [JsonPropertyName("managerActionMessage")]
    public string? ManagerActionMessage { get; set; }

    [JsonPropertyName("managerUserId")]
    public string? ManagerUserId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recipientActionDateTime")]
    public DateTime? RecipientActionDateTime { get; set; }

    [JsonPropertyName("recipientActionMessage")]
    public string? RecipientActionMessage { get; set; }

    [JsonPropertyName("recipientShiftId")]
    public string? RecipientShiftId { get; set; }

    [JsonPropertyName("recipientUserId")]
    public string? RecipientUserId { get; set; }

    [JsonPropertyName("senderDateTime")]
    public DateTime? SenderDateTime { get; set; }

    [JsonPropertyName("senderMessage")]
    public string? SenderMessage { get; set; }

    [JsonPropertyName("senderShiftId")]
    public string? SenderShiftId { get; set; }

    [JsonPropertyName("senderUserId")]
    public string? SenderUserId { get; set; }

    [JsonPropertyName("state")]
    public SwapShiftsChangeRequestStateConstant? State { get; set; }
}
