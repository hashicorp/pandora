// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RedundantAssignmentAlertIncidentModel
{
    [JsonPropertyName("assigneeDisplayName")]
    public string? AssigneeDisplayName { get; set; }

    [JsonPropertyName("assigneeId")]
    public string? AssigneeId { get; set; }

    [JsonPropertyName("assigneeUserPrincipalName")]
    public string? AssigneeUserPrincipalName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActivationDateTime")]
    public DateTime? LastActivationDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }

    [JsonPropertyName("roleDisplayName")]
    public string? RoleDisplayName { get; set; }

    [JsonPropertyName("roleTemplateId")]
    public string? RoleTemplateId { get; set; }
}
