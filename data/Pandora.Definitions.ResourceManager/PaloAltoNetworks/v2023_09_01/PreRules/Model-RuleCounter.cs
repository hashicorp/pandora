using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.PreRules;


internal class RuleCounterModel
{
    [JsonPropertyName("appSeen")]
    public AppSeenDataModel? AppSeen { get; set; }

    [JsonPropertyName("firewallName")]
    public string? FirewallName { get; set; }

    [JsonPropertyName("hitCount")]
    public int? HitCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTimestamp")]
    public DateTime? LastUpdatedTimestamp { get; set; }

    [JsonPropertyName("priority")]
    [Required]
    public string Priority { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("requestTimestamp")]
    public DateTime? RequestTimestamp { get; set; }

    [JsonPropertyName("ruleListName")]
    public string? RuleListName { get; set; }

    [JsonPropertyName("ruleName")]
    [Required]
    public string RuleName { get; set; }

    [JsonPropertyName("ruleStackName")]
    public string? RuleStackName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }
}
