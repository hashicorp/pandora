using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;


internal class ScheduledQueryRulePropertiesModel
{
    [JsonPropertyName("actions")]
    public ActionsModel? Actions { get; set; }

    [JsonPropertyName("autoMitigate")]
    public bool? AutoMitigate { get; set; }

    [JsonPropertyName("checkWorkspaceAlertsStorageConfigured")]
    public bool? CheckWorkspaceAlertsStorageConfigured { get; set; }

    [JsonPropertyName("createdWithApiVersion")]
    public string? CreatedWithApiVersion { get; set; }

    [JsonPropertyName("criteria")]
    public ScheduledQueryRuleCriteriaModel? Criteria { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("evaluationFrequency")]
    public string? EvaluationFrequency { get; set; }

    [JsonPropertyName("isLegacyLogAnalyticsRule")]
    public bool? IsLegacyLogAnalyticsRule { get; set; }

    [JsonPropertyName("isWorkspaceAlertsStorageConfigured")]
    public bool? IsWorkspaceAlertsStorageConfigured { get; set; }

    [JsonPropertyName("muteActionsDuration")]
    public string? MuteActionsDuration { get; set; }

    [JsonPropertyName("overrideQueryTimeRange")]
    public string? OverrideQueryTimeRange { get; set; }

    [JsonPropertyName("scopes")]
    public List<string>? Scopes { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [JsonPropertyName("skipQueryValidation")]
    public bool? SkipQueryValidation { get; set; }

    [JsonPropertyName("targetResourceTypes")]
    public List<string>? TargetResourceTypes { get; set; }

    [JsonPropertyName("windowSize")]
    public string? WindowSize { get; set; }
}
