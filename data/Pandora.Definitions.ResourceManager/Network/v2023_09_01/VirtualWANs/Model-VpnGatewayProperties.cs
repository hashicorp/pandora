using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualWANs;


internal class VpnGatewayPropertiesModel
{
    [JsonPropertyName("bgpSettings")]
    public BgpSettingsModel? BgpSettings { get; set; }

    [JsonPropertyName("connections")]
    public List<VpnConnectionModel>? Connections { get; set; }

    [JsonPropertyName("enableBgpRouteTranslationForNat")]
    public bool? EnableBgpRouteTranslationForNat { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<VpnGatewayIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("isRoutingPreferenceInternet")]
    public bool? IsRoutingPreferenceInternet { get; set; }

    [JsonPropertyName("natRules")]
    public List<VpnGatewayNatRuleModel>? NatRules { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("virtualHub")]
    public SubResourceModel? VirtualHub { get; set; }

    [JsonPropertyName("vpnGatewayScaleUnit")]
    public int? VpnGatewayScaleUnit { get; set; }
}
