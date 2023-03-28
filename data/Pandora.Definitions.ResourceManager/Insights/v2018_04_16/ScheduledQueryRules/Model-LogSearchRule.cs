using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_04_16.ScheduledQueryRules;


internal class LogSearchRuleModel
{
    [JsonPropertyName("action")]
    [Required]
    public ActionModel Action { get; set; }

    [JsonPropertyName("autoMitigate")]
    public bool? AutoMitigate { get; set; }

    [JsonPropertyName("createdWithApiVersion")]
    public string? CreatedWithApiVersion { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    public EnabledConstant? Enabled { get; set; }

    [JsonPropertyName("isLegacyLogAnalyticsRule")]
    public bool? IsLegacyLogAnalyticsRule { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTime")]
    public DateTime? LastUpdatedTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("schedule")]
    public ScheduleModel? Schedule { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public SourceModel Source { get; set; }
}
