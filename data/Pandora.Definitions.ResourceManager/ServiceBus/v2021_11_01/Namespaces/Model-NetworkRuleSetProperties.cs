using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.Namespaces;


internal class NetworkRuleSetPropertiesModel
{
    [JsonPropertyName("defaultAction")]
    public DefaultActionConstant? DefaultAction { get; set; }

    [JsonPropertyName("ipRules")]
    public List<NWRuleSetIPRulesModel>? IPRules { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessFlagConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("trustedServiceAccessEnabled")]
    public bool? TrustedServiceAccessEnabled { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<NWRuleSetVirtualNetworkRulesModel>? VirtualNetworkRules { get; set; }
}
