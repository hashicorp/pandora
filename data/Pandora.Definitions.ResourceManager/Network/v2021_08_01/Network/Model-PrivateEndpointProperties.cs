using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class PrivateEndpointPropertiesModel
{
    [JsonPropertyName("applicationSecurityGroups")]
    public List<ApplicationSecurityGroupModel>? ApplicationSecurityGroups { get; set; }

    [JsonPropertyName("customDnsConfigs")]
    public List<CustomDnsConfigPropertiesFormatModel>? CustomDnsConfigs { get; set; }

    [JsonPropertyName("customNetworkInterfaceName")]
    public string? CustomNetworkInterfaceName { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<PrivateEndpointIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("manualPrivateLinkServiceConnections")]
    public List<PrivateLinkServiceConnectionModel>? ManualPrivateLinkServiceConnections { get; set; }

    [JsonPropertyName("networkInterfaces")]
    public List<NetworkInterfaceModel>? NetworkInterfaces { get; set; }

    [JsonPropertyName("privateLinkServiceConnections")]
    public List<PrivateLinkServiceConnectionModel>? PrivateLinkServiceConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("subnet")]
    public SubnetModel? Subnet { get; set; }
}
