using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;


internal class EffectiveNetworkSecurityRuleModel
{
    [JsonPropertyName("access")]
    public SecurityRuleAccessConstant? Access { get; set; }

    [JsonPropertyName("destinationAddressPrefix")]
    public string? DestinationAddressPrefix { get; set; }

    [JsonPropertyName("destinationAddressPrefixes")]
    public List<string>? DestinationAddressPrefixes { get; set; }

    [JsonPropertyName("destinationPortRange")]
    public string? DestinationPortRange { get; set; }

    [JsonPropertyName("destinationPortRanges")]
    public List<string>? DestinationPortRanges { get; set; }

    [JsonPropertyName("direction")]
    public SecurityRuleDirectionConstant? Direction { get; set; }

    [JsonPropertyName("expandedDestinationAddressPrefix")]
    public List<string>? ExpandedDestinationAddressPrefix { get; set; }

    [JsonPropertyName("expandedSourceAddressPrefix")]
    public List<string>? ExpandedSourceAddressPrefix { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("protocol")]
    public EffectiveSecurityRuleProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("sourceAddressPrefix")]
    public string? SourceAddressPrefix { get; set; }

    [JsonPropertyName("sourceAddressPrefixes")]
    public List<string>? SourceAddressPrefixes { get; set; }

    [JsonPropertyName("sourcePortRange")]
    public string? SourcePortRange { get; set; }

    [JsonPropertyName("sourcePortRanges")]
    public List<string>? SourcePortRanges { get; set; }
}
