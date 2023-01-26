using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerEffectiveSecurityAdminRules;


internal abstract class EffectiveBaseSecurityAdminRuleModel
{
    [JsonPropertyName("configurationDescription")]
    public string? ConfigurationDescription { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("kind")]
    [ProvidesTypeHint]
    [Required]
    public EffectiveAdminRuleKindConstant Kind { get; set; }

    [JsonPropertyName("ruleCollectionAppliesToGroups")]
    public List<NetworkManagerSecurityGroupItemModel>? RuleCollectionAppliesToGroups { get; set; }

    [JsonPropertyName("ruleCollectionDescription")]
    public string? RuleCollectionDescription { get; set; }

    [JsonPropertyName("ruleGroups")]
    public List<ConfigurationGroupModel>? RuleGroups { get; set; }
}
