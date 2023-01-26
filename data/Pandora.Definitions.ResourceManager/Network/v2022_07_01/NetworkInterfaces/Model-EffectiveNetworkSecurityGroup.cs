using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkInterfaces;


internal class EffectiveNetworkSecurityGroupModel
{
    [JsonPropertyName("association")]
    public EffectiveNetworkSecurityGroupAssociationModel? Association { get; set; }

    [JsonPropertyName("effectiveSecurityRules")]
    public List<EffectiveNetworkSecurityRuleModel>? EffectiveSecurityRules { get; set; }

    [JsonPropertyName("networkSecurityGroup")]
    public SubResourceModel? NetworkSecurityGroup { get; set; }

    [JsonPropertyName("tagMap")]
    public Dictionary<string, List<string>>? TagMap { get; set; }
}
