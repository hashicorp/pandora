using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VpnServerConfigurations;


internal class P2SConnectionConfigurationPropertiesModel
{
    [JsonPropertyName("configurationPolicyGroupAssociations")]
    public List<SubResourceModel>? ConfigurationPolicyGroupAssociations { get; set; }

    [JsonPropertyName("enableInternetSecurity")]
    public bool? EnableInternetSecurity { get; set; }

    [JsonPropertyName("previousConfigurationPolicyGroupAssociations")]
    public List<VpnServerConfigurationPolicyGroupModel>? PreviousConfigurationPolicyGroupAssociations { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routingConfiguration")]
    public RoutingConfigurationModel? RoutingConfiguration { get; set; }

    [JsonPropertyName("vpnClientAddressPool")]
    public AddressSpaceModel? VpnClientAddressPool { get; set; }
}
