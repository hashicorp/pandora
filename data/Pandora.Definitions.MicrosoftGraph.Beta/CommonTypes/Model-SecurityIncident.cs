// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityIncidentModel
{
    [JsonPropertyName("alerts")]
    public List<AlertModel>? Alerts { get; set; }

    [JsonPropertyName("assignedTo")]
    public string? AssignedTo { get; set; }

    [JsonPropertyName("classification")]
    public AlertClassificationConstant? Classification { get; set; }

    [JsonPropertyName("comments")]
    public List<AlertCommentModel>? Comments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customTags")]
    public List<string>? CustomTags { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("determination")]
    public AlertDeterminationConstant? Determination { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incidentWebUrl")]
    public string? IncidentWebUrl { get; set; }

    [JsonPropertyName("lastUpdateDateTime")]
    public DateTime? LastUpdateDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recommendedActions")]
    public string? RecommendedActions { get; set; }

    [JsonPropertyName("recommendedHuntingQueries")]
    public List<RecommendedHuntingQueryModel>? RecommendedHuntingQueries { get; set; }

    [JsonPropertyName("redirectIncidentId")]
    public string? RedirectIncidentId { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [JsonPropertyName("status")]
    public IncidentStatusConstant? Status { get; set; }

    [JsonPropertyName("systemTags")]
    public List<string>? SystemTags { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
