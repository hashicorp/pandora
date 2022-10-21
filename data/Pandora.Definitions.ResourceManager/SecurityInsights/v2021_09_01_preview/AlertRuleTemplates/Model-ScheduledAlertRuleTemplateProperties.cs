using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AlertRuleTemplates;


internal class ScheduledAlertRuleTemplatePropertiesModel
{
    [JsonPropertyName("alertDetailsOverride")]
    public AlertDetailsOverrideModel? AlertDetailsOverride { get; set; }

    [JsonPropertyName("alertRulesCreatedByTemplateCount")]
    [Required]
    public int AlertRulesCreatedByTemplateCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateUTC")]
    public DateTime? CreatedDateUTC { get; set; }

    [JsonPropertyName("customDetails")]
    public Dictionary<string, string>? CustomDetails { get; set; }

    [JsonPropertyName("description")]
    [Required]
    public string Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("entityMappings")]
    public List<EntityMappingModel>? EntityMappings { get; set; }

    [JsonPropertyName("eventGroupingSettings")]
    public EventGroupingSettingsModel? EventGroupingSettings { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedDateUTC")]
    public DateTime? LastUpdatedDateUTC { get; set; }

    [JsonPropertyName("query")]
    [Required]
    public string Query { get; set; }

    [JsonPropertyName("queryFrequency")]
    [Required]
    public string QueryFrequency { get; set; }

    [JsonPropertyName("queryPeriod")]
    [Required]
    public string QueryPeriod { get; set; }

    [JsonPropertyName("requiredDataConnectors")]
    public List<AlertRuleTemplateDataSourceModel>? RequiredDataConnectors { get; set; }

    [JsonPropertyName("severity")]
    [Required]
    public AlertSeverityConstant Severity { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public TemplateStatusConstant Status { get; set; }

    [JsonPropertyName("tactics")]
    public List<AttackTacticConstant>? Tactics { get; set; }

    [JsonPropertyName("triggerOperator")]
    [Required]
    public TriggerOperatorConstant TriggerOperator { get; set; }

    [JsonPropertyName("triggerThreshold")]
    [Required]
    public int TriggerThreshold { get; set; }

    [JsonPropertyName("version")]
    [Required]
    public string Version { get; set; }
}
