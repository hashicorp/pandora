using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.VirtualNetworkLinks;


internal class VirtualNetworkLinkPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("registrationEnabled")]
    public bool? RegistrationEnabled { get; set; }

    [JsonPropertyName("virtualNetwork")]
    public SubResourceModel? VirtualNetwork { get; set; }

    [JsonPropertyName("virtualNetworkLinkState")]
    public VirtualNetworkLinkStateConstant? VirtualNetworkLinkState { get; set; }
}
