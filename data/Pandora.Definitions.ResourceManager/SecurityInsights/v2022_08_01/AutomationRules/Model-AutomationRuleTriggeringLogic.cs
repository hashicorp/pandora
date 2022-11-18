using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AutomationRules;


internal class AutomationRuleTriggeringLogicModel
{
    [MaxItems(50)]
    [JsonPropertyName("conditions")]
    public List<AutomationRuleConditionModel>? Conditions { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTimeUtc")]
    public DateTime? ExpirationTimeUtc { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }

    [JsonPropertyName("triggersOn")]
    [Required]
    public TriggersOnConstant TriggersOn { get; set; }

    [JsonPropertyName("triggersWhen")]
    [Required]
    public TriggersWhenConstant TriggersWhen { get; set; }
}
