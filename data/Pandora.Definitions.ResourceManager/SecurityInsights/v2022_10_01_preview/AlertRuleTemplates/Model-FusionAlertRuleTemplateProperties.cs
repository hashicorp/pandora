using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AlertRuleTemplates;


internal class FusionAlertRuleTemplatePropertiesModel
{
    [JsonPropertyName("alertRulesCreatedByTemplateCount")]
    public int? AlertRulesCreatedByTemplateCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateUTC")]
    public DateTime? CreatedDateUTC { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedDateUTC")]
    public DateTime? LastUpdatedDateUTC { get; set; }

    [JsonPropertyName("requiredDataConnectors")]
    public List<AlertRuleTemplateDataSourceModel>? RequiredDataConnectors { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [JsonPropertyName("sourceSettings")]
    public List<FusionTemplateSourceSettingModel>? SourceSettings { get; set; }

    [JsonPropertyName("status")]
    public TemplateStatusConstant? Status { get; set; }

    [JsonPropertyName("tactics")]
    public List<AttackTacticConstant>? Tactics { get; set; }

    [JsonPropertyName("techniques")]
    public List<string>? Techniques { get; set; }
}
