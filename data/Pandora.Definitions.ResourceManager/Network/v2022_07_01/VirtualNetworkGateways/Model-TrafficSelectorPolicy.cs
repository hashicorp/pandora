using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGateways;


internal class TrafficSelectorPolicyModel
{
    [JsonPropertyName("localAddressRanges")]
    [Required]
    public List<string> LocalAddressRanges { get; set; }

    [JsonPropertyName("remoteAddressRanges")]
    [Required]
    public List<string> RemoteAddressRanges { get; set; }
}
