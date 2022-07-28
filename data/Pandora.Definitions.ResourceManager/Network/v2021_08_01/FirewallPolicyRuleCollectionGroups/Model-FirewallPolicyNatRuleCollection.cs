using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.FirewallPolicyRuleCollectionGroups;

[ValueForType("FirewallPolicyNatRuleCollection")]
internal class FirewallPolicyNatRuleCollectionModel : FirewallPolicyRuleCollectionModel
{
    [JsonPropertyName("action")]
    public FirewallPolicyNatRuleCollectionActionModel? Action { get; set; }

    [JsonPropertyName("rules")]
    public List<FirewallPolicyRuleModel>? Rules { get; set; }
}
