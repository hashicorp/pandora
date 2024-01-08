using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.PrivateLinkServices;


internal class NatRulePortMappingModel
{
    [JsonPropertyName("backendPort")]
    public int? BackendPort { get; set; }

    [JsonPropertyName("frontendPort")]
    public int? FrontendPort { get; set; }

    [JsonPropertyName("inboundNatRuleName")]
    public string? InboundNatRuleName { get; set; }
}
