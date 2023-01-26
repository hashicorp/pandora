using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualRouters;


internal class VirtualRouterPropertiesFormatModel
{
    [JsonPropertyName("hostedGateway")]
    public SubResourceModel? HostedGateway { get; set; }

    [JsonPropertyName("hostedSubnet")]
    public SubResourceModel? HostedSubnet { get; set; }

    [JsonPropertyName("peerings")]
    public List<SubResourceModel>? Peerings { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("virtualRouterAsn")]
    public int? VirtualRouterAsn { get; set; }

    [JsonPropertyName("virtualRouterIps")]
    public List<string>? VirtualRouterIPs { get; set; }
}
