using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PacketCaptures;


internal class PacketCaptureFilterModel
{
    [JsonPropertyName("localIPAddress")]
    public string? LocalIPAddress { get; set; }

    [JsonPropertyName("localPort")]
    public string? LocalPort { get; set; }

    [JsonPropertyName("protocol")]
    public PcProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("remoteIPAddress")]
    public string? RemoteIPAddress { get; set; }

    [JsonPropertyName("remotePort")]
    public string? RemotePort { get; set; }
}
