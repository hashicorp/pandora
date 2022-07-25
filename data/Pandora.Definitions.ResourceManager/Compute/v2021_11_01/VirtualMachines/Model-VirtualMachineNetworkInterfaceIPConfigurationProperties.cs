using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;


internal class VirtualMachineNetworkInterfaceIPConfigurationPropertiesModel
{
    [JsonPropertyName("applicationGatewayBackendAddressPools")]
    public List<SubResourceModel>? ApplicationGatewayBackendAddressPools { get; set; }

    [JsonPropertyName("applicationSecurityGroups")]
    public List<SubResourceModel>? ApplicationSecurityGroups { get; set; }

    [JsonPropertyName("loadBalancerBackendAddressPools")]
    public List<SubResourceModel>? LoadBalancerBackendAddressPools { get; set; }

    [JsonPropertyName("primary")]
    public bool? Primary { get; set; }

    [JsonPropertyName("privateIPAddressVersion")]
    public IPVersionsConstant? PrivateIPAddressVersion { get; set; }

    [JsonPropertyName("publicIPAddressConfiguration")]
    public VirtualMachinePublicIPAddressConfigurationModel? PublicIPAddressConfiguration { get; set; }

    [JsonPropertyName("subnet")]
    public SubResourceModel? Subnet { get; set; }
}
