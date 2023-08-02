// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityAlertModel
{
    [JsonPropertyName("actorDisplayName")]
    public string? ActorDisplayName { get; set; }

    [JsonPropertyName("alertWebUrl")]
    public string? AlertWebUrl { get; set; }

    [JsonPropertyName("assignedTo")]
    public string? AssignedTo { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("classification")]
    public AlertClassificationConstant? Classification { get; set; }

    [JsonPropertyName("comments")]
    public List<AlertCommentModel>? Comments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detectionSource")]
    public DetectionSourceConstant? DetectionSource { get; set; }

    [JsonPropertyName("detectorId")]
    public string? DetectorId { get; set; }

    [JsonPropertyName("determination")]
    public AlertDeterminationConstant? Determination { get; set; }

    [JsonPropertyName("evidence")]
    public List<AlertEvidenceModel>? Evidence { get; set; }

    [JsonPropertyName("firstActivityDateTime")]
    public DateTime? FirstActivityDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incidentId")]
    public string? IncidentId { get; set; }

    [JsonPropertyName("incidentWebUrl")]
    public string? IncidentWebUrl { get; set; }

    [JsonPropertyName("lastActivityDateTime")]
    public DateTime? LastActivityDateTime { get; set; }

    [JsonPropertyName("lastUpdateDateTime")]
    public DateTime? LastUpdateDateTime { get; set; }

    [JsonPropertyName("mitreTechniques")]
    public List<string>? MitreTechniques { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("providerAlertId")]
    public string? ProviderAlertId { get; set; }

    [JsonPropertyName("recommendedActions")]
    public string? RecommendedActions { get; set; }

    [JsonPropertyName("resolvedDateTime")]
    public DateTime? ResolvedDateTime { get; set; }

    [JsonPropertyName("serviceSource")]
    public ServiceSourceConstant? ServiceSource { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [JsonPropertyName("status")]
    public AlertStatusConstant? Status { get; set; }

    [JsonPropertyName("systemTags")]
    public List<string>? SystemTags { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("threatDisplayName")]
    public string? ThreatDisplayName { get; set; }

    [JsonPropertyName("threatFamilyName")]
    public string? ThreatFamilyName { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
