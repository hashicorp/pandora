// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ScheduleChangeRequestModel
{
    [JsonPropertyName("assignedTo")]
    public ScheduleChangeRequestActorConstant? AssignedTo { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

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

    [JsonPropertyName("senderDateTime")]
    public DateTime? SenderDateTime { get; set; }

    [JsonPropertyName("senderMessage")]
    public string? SenderMessage { get; set; }

    [JsonPropertyName("senderUserId")]
    public string? SenderUserId { get; set; }

    [JsonPropertyName("state")]
    public ScheduleChangeStateConstant? State { get; set; }
}
