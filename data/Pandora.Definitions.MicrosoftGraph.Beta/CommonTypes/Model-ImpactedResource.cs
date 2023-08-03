// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImpactedResourceModel
{
    [JsonPropertyName("addedDateTime")]
    public DateTime? AddedDateTime { get; set; }

    [JsonPropertyName("additionalDetails")]
    public List<KeyValueModel>? AdditionalDetails { get; set; }

    [JsonPropertyName("apiUrl")]
    public string? ApiUrl { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public string? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("portalUrl")]
    public string? PortalUrl { get; set; }

    [JsonPropertyName("postponeUntilDateTime")]
    public DateTime? PostponeUntilDateTime { get; set; }

    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    [JsonPropertyName("recommendationId")]
    public string? RecommendationId { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("status")]
    public RecommendationStatusConstant? Status { get; set; }

    [JsonPropertyName("subjectId")]
    public string? SubjectId { get; set; }
}
