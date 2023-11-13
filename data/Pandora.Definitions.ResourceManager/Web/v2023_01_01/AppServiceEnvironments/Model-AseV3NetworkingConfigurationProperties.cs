using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceEnvironments;


internal class AseV3NetworkingConfigurationPropertiesModel
{
    [JsonPropertyName("allowNewPrivateEndpointConnections")]
    public bool? AllowNewPrivateEndpointConnections { get; set; }

    [JsonPropertyName("externalInboundIpAddresses")]
    public List<string>? ExternalInboundIPAddresses { get; set; }

    [JsonPropertyName("ftpEnabled")]
    public bool? FtpEnabled { get; set; }

    [JsonPropertyName("inboundIpAddressOverride")]
    public string? InboundIPAddressOverride { get; set; }

    [JsonPropertyName("internalInboundIpAddresses")]
    public List<string>? InternalInboundIPAddresses { get; set; }

    [JsonPropertyName("linuxOutboundIpAddresses")]
    public List<string>? LinuxOutboundIPAddresses { get; set; }

    [JsonPropertyName("remoteDebugEnabled")]
    public bool? RemoteDebugEnabled { get; set; }

    [JsonPropertyName("windowsOutboundIpAddresses")]
    public List<string>? WindowsOutboundIPAddresses { get; set; }
}
