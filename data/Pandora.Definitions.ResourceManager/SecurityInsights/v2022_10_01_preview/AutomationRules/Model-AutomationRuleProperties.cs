using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AutomationRules;


internal class AutomationRulePropertiesModel
{
    [MaxItems(20)]
    [JsonPropertyName("actions")]
    [Required]
    public List<AutomationRuleActionModel> Actions { get; set; }

    [JsonPropertyName("createdBy")]
    public ClientInfoModel? CreatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimeUtc")]
    public DateTime? CreatedTimeUtc { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public ClientInfoModel? LastModifiedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTimeUtc")]
    public DateTime? LastModifiedTimeUtc { get; set; }

    [JsonPropertyName("order")]
    [Required]
    public int Order { get; set; }

    [JsonPropertyName("triggeringLogic")]
    [Required]
    public AutomationRuleTriggeringLogicModel TriggeringLogic { get; set; }
}
