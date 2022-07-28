using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkInterfaces;


internal class InboundNatPoolPropertiesFormatModel
{
    [JsonPropertyName("backendPort")]
    [Required]
    public int BackendPort { get; set; }

    [JsonPropertyName("enableFloatingIP")]
    public bool? EnableFloatingIP { get; set; }

    [JsonPropertyName("enableTcpReset")]
    public bool? EnableTcpReset { get; set; }

    [JsonPropertyName("frontendIPConfiguration")]
    public SubResourceModel? FrontendIPConfiguration { get; set; }

    [JsonPropertyName("frontendPortRangeEnd")]
    [Required]
    public int FrontendPortRangeEnd { get; set; }

    [JsonPropertyName("frontendPortRangeStart")]
    [Required]
    public int FrontendPortRangeStart { get; set; }

    [JsonPropertyName("idleTimeoutInMinutes")]
    public int? IdleTimeoutInMinutes { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public TransportProtocolConstant Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
