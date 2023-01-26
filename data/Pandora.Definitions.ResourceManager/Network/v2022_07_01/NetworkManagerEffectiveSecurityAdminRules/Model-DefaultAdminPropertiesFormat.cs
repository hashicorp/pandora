using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerEffectiveSecurityAdminRules;


internal class DefaultAdminPropertiesFormatModel
{
    [JsonPropertyName("access")]
    public SecurityConfigurationRuleAccessConstant? Access { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinationPortRanges")]
    public List<string>? DestinationPortRanges { get; set; }

    [JsonPropertyName("destinations")]
    public List<AddressPrefixItemModel>? Destinations { get; set; }

    [JsonPropertyName("direction")]
    public SecurityConfigurationRuleDirectionConstant? Direction { get; set; }

    [JsonPropertyName("flag")]
    public string? Flag { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("protocol")]
    public SecurityConfigurationRuleProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sourcePortRanges")]
    public List<string>? SourcePortRanges { get; set; }

    [JsonPropertyName("sources")]
    public List<AddressPrefixItemModel>? Sources { get; set; }
}
