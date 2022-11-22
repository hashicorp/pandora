using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.AlertRules;


internal class GroupingConfigurationModel
{
    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("groupByAlertDetails")]
    public List<AlertDetailConstant>? GroupByAlertDetails { get; set; }

    [JsonPropertyName("groupByCustomDetails")]
    public List<string>? GroupByCustomDetails { get; set; }

    [JsonPropertyName("groupByEntities")]
    public List<EntityMappingTypeConstant>? GroupByEntities { get; set; }

    [JsonPropertyName("lookbackDuration")]
    [Required]
    public string LookbackDuration { get; set; }

    [JsonPropertyName("matchingMethod")]
    [Required]
    public MatchingMethodConstant MatchingMethod { get; set; }

    [JsonPropertyName("reopenClosedIncident")]
    [Required]
    public bool ReopenClosedIncident { get; set; }
}
