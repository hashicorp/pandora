using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGatewayConnections;


internal class VirtualNetworkGatewayNatRulePropertiesModel
{
    [JsonPropertyName("externalMappings")]
    public List<VpnNatRuleMappingModel>? ExternalMappings { get; set; }

    [JsonPropertyName("ipConfigurationId")]
    public string? IPConfigurationId { get; set; }

    [JsonPropertyName("internalMappings")]
    public List<VpnNatRuleMappingModel>? InternalMappings { get; set; }

    [JsonPropertyName("mode")]
    public VpnNatRuleModeConstant? Mode { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("type")]
    public VpnNatRuleTypeConstant? Type { get; set; }
}
