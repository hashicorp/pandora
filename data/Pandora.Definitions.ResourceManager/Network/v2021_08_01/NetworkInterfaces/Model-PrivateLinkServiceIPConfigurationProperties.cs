using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkInterfaces;


internal class PrivateLinkServiceIPConfigurationPropertiesModel
{
    [JsonPropertyName("primary")]
    public bool? Primary { get; set; }

    [JsonPropertyName("privateIPAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("privateIPAddressVersion")]
    public IPVersionConstant? PrivateIPAddressVersion { get; set; }

    [JsonPropertyName("privateIPAllocationMethod")]
    public IPAllocationMethodConstant? PrivateIPAllocationMethod { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("subnet")]
    public SubnetModel? Subnet { get; set; }
}
