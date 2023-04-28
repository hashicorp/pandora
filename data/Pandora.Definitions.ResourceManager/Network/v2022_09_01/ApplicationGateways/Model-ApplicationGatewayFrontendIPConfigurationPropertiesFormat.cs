using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ApplicationGateways;


internal class ApplicationGatewayFrontendIPConfigurationPropertiesFormatModel
{
    [JsonPropertyName("privateIPAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("privateIPAllocationMethod")]
    public IPAllocationMethodConstant? PrivateIPAllocationMethod { get; set; }

    [JsonPropertyName("privateLinkConfiguration")]
    public SubResourceModel? PrivateLinkConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPAddress")]
    public SubResourceModel? PublicIPAddress { get; set; }

    [JsonPropertyName("subnet")]
    public SubResourceModel? Subnet { get; set; }
}
