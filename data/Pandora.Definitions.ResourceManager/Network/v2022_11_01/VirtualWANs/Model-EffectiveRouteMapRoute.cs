using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.VirtualWANs;


internal class EffectiveRouteMapRouteModel
{
    [JsonPropertyName("asPath")]
    public string? AsPath { get; set; }

    [JsonPropertyName("bgpCommunities")]
    public string? BgpCommunities { get; set; }

    [JsonPropertyName("prefix")]
    public string? Prefix { get; set; }
}
