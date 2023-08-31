using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class NetworkAttachmentModel
{
    [JsonPropertyName("attachedNetworkId")]
    [Required]
    public string AttachedNetworkId { get; set; }

    [JsonPropertyName("defaultGateway")]
    public DefaultGatewayConstant? DefaultGateway { get; set; }

    [JsonPropertyName("ipAllocationMethod")]
    [Required]
    public VirtualMachineIPAllocationMethodConstant IPAllocationMethod { get; set; }

    [JsonPropertyName("ipv4Address")]
    public string? IPv4Address { get; set; }

    [JsonPropertyName("ipv6Address")]
    public string? IPv6Address { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("networkAttachmentName")]
    public string? NetworkAttachmentName { get; set; }
}
