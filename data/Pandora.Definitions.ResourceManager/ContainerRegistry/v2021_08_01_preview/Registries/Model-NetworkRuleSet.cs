using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.Registries;


internal class NetworkRuleSetModel
{
    [JsonPropertyName("defaultAction")]
    [Required]
    public DefaultActionConstant DefaultAction { get; set; }

    [JsonPropertyName("ipRules")]
    public List<IPRuleModel>? IPRules { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<VirtualNetworkRuleModel>? VirtualNetworkRules { get; set; }
}
