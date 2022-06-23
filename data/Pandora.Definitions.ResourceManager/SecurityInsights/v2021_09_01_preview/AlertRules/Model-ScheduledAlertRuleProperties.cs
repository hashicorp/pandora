using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AlertRules;


internal class ScheduledAlertRulePropertiesModel
{
    [JsonPropertyName("alertDetailsOverride")]
    public AlertDetailsOverrideModel? AlertDetailsOverride { get; set; }

    [JsonPropertyName("alertRuleTemplateName")]
    public string? AlertRuleTemplateName { get; set; }

    [JsonPropertyName("customDetails")]
    public Dictionary<string, string>? CustomDetails { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("entityMappings")]
    public List<EntityMappingModel>? EntityMappings { get; set; }

    [JsonPropertyName("eventGroupingSettings")]
    public EventGroupingSettingsModel? EventGroupingSettings { get; set; }

    [JsonPropertyName("incidentConfiguration")]
    public IncidentConfigurationModel? IncidentConfiguration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedUtc")]
    public DateTime? LastModifiedUtc { get; set; }

    [JsonPropertyName("query")]
    [Required]
    public string Query { get; set; }

    [JsonPropertyName("queryFrequency")]
    [Required]
    public string QueryFrequency { get; set; }

    [JsonPropertyName("queryPeriod")]
    [Required]
    public string QueryPeriod { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public AlertSeverityConstant Severity { get; set; }

    [JsonPropertyName("suppressionDuration")]
    [Required]
    public string SuppressionDuration { get; set; }

    [JsonPropertyName("suppressionEnabled")]
    [Required]
    public bool SuppressionEnabled { get; set; }

    [JsonPropertyName("tactics")]
    public List<AttackTacticConstant>? Tactics { get; set; }

    [JsonPropertyName("templateVersion")]
    public string? TemplateVersion { get; set; }

    [JsonPropertyName("triggerOperator")]
    [Required]
    public TriggerOperatorConstant TriggerOperator { get; set; }

    [JsonPropertyName("triggerThreshold")]
    [Required]
    public int TriggerThreshold { get; set; }
}
