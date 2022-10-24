using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.IncidentEntities;


internal class SecurityAlertPropertiesModel
{
    [JsonPropertyName("additionalData")]
    public Dictionary<string, object>? AdditionalData { get; set; }

    [JsonPropertyName("alertDisplayName")]
    public string? AlertDisplayName { get; set; }

    [JsonPropertyName("alertLink")]
    public string? AlertLink { get; set; }

    [JsonPropertyName("alertType")]
    public string? AlertType { get; set; }

    [JsonPropertyName("compromisedEntity")]
    public string? CompromisedEntity { get; set; }

    [JsonPropertyName("confidenceLevel")]
    public ConfidenceLevelConstant? ConfidenceLevel { get; set; }

    [JsonPropertyName("confidenceReasons")]
    public List<SecurityAlertPropertiesConfidenceReasonsInlinedModel>? ConfidenceReasons { get; set; }

    [JsonPropertyName("confidenceScore")]
    public float? ConfidenceScore { get; set; }

    [JsonPropertyName("confidenceScoreStatus")]
    public ConfidenceScoreStatusConstant? ConfidenceScoreStatus { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTimeUtc")]
    public DateTime? EndTimeUtc { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("intent")]
    public KillChainIntentConstant? Intent { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("processingEndTime")]
    public DateTime? ProcessingEndTime { get; set; }

    [JsonPropertyName("productComponentName")]
    public string? ProductComponentName { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("productVersion")]
    public string? ProductVersion { get; set; }

    [JsonPropertyName("providerAlertId")]
    public string? ProviderAlertId { get; set; }

    [JsonPropertyName("remediationSteps")]
    public List<string>? RemediationSteps { get; set; }

    [JsonPropertyName("resourceIdentifiers")]
    public List<object>? ResourceIdentifiers { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTimeUtc")]
    public DateTime? StartTimeUtc { get; set; }

    [JsonPropertyName("status")]
    public AlertStatusConstant? Status { get; set; }

    [JsonPropertyName("systemAlertId")]
    public string? SystemAlertId { get; set; }

    [JsonPropertyName("tactics")]
    public List<AttackTacticConstant>? Tactics { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeGenerated")]
    public DateTime? TimeGenerated { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }
}
