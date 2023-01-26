using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class PeerRouteModel
{
    [JsonPropertyName("asPath")]
    public string? AsPath { get; set; }

    [JsonPropertyName("localAddress")]
    public string? LocalAddress { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }

    [JsonPropertyName("nextHop")]
    public string? NextHop { get; set; }

    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    [JsonPropertyName("sourcePeer")]
    public string? SourcePeer { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
