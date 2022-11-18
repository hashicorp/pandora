using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AlertRules;


internal class MicrosoftSecurityIncidentCreationAlertRulePropertiesModel
{
    [JsonPropertyName("alertRuleTemplateName")]
    public string? AlertRuleTemplateName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("displayNamesExcludeFilter")]
    public List<string>? DisplayNamesExcludeFilter { get; set; }

    [JsonPropertyName("displayNamesFilter")]
    public List<string>? DisplayNamesFilter { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedUtc")]
    public DateTime? LastModifiedUtc { get; set; }

    [JsonPropertyName("productFilter")]
    [Required]
    public MicrosoftSecurityProductNameConstant ProductFilter { get; set; }

    [JsonPropertyName("severitiesFilter")]
    public List<AlertSeverityConstant>? SeveritiesFilter { get; set; }
}
