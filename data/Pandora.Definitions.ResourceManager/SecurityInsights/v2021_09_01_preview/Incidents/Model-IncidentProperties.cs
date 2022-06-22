using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Incidents;


internal class IncidentPropertiesModel
{
    [JsonPropertyName("additionalData")]
    public IncidentAdditionalDataModel? AdditionalData { get; set; }

    [JsonPropertyName("classification")]
    public IncidentClassificationConstant? Classification { get; set; }

    [JsonPropertyName("classificationComment")]
    public string? ClassificationComment { get; set; }

    [JsonPropertyName("classificationReason")]
    public IncidentClassificationReasonConstant? ClassificationReason { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimeUtc")]
    public DateTime? CreatedTimeUtc { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("firstActivityTimeUtc")]
    public DateTime? FirstActivityTimeUtc { get; set; }

    [JsonPropertyName("incidentNumber")]
    public int? IncidentNumber { get; set; }

    [JsonPropertyName("incidentUrl")]
    public string? IncidentUrl { get; set; }

    [JsonPropertyName("labels")]
    public List<IncidentLabelModel>? Labels { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastActivityTimeUtc")]
    public DateTime? LastActivityTimeUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTimeUtc")]
    public DateTime? LastModifiedTimeUtc { get; set; }

    [JsonPropertyName("owner")]
    public IncidentOwnerInfoModel? Owner { get; set; }

    [JsonPropertyName("providerIncidentId")]
    public string? ProviderIncidentId { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("relatedAnalyticRuleIds")]
    public List<string>? RelatedAnalyticRuleIds { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public IncidentSeverityConstant Severity { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public IncidentStatusConstant Status { get; set; }

    [JsonPropertyName("teamInformation")]
    public TeamInformationModel? TeamInformation { get; set; }

    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; }
}
