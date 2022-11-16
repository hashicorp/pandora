using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.CognitiveServicesAccounts;


internal class NetworkRuleSetModel
{
    [JsonPropertyName("defaultAction")]
    public NetworkRuleActionConstant? DefaultAction { get; set; }

    [JsonPropertyName("ipRules")]
    public List<IPRuleModel>? IPRules { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<VirtualNetworkRuleModel>? VirtualNetworkRules { get; set; }
}
