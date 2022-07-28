using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Subnets;


internal class SecurityRulePropertiesFormatModel
{
    [JsonPropertyName("access")]
    [Required]
    public SecurityRuleAccessConstant Access { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinationAddressPrefix")]
    public string? DestinationAddressPrefix { get; set; }

    [JsonPropertyName("destinationAddressPrefixes")]
    public List<string>? DestinationAddressPrefixes { get; set; }

    [JsonPropertyName("destinationApplicationSecurityGroups")]
    public List<ApplicationSecurityGroupModel>? DestinationApplicationSecurityGroups { get; set; }

    [JsonPropertyName("destinationPortRange")]
    public string? DestinationPortRange { get; set; }

    [JsonPropertyName("destinationPortRanges")]
    public List<string>? DestinationPortRanges { get; set; }

    [JsonPropertyName("direction")]
    [Required]
    public SecurityRuleDirectionConstant Direction { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public SecurityRuleProtocolConstant Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sourceAddressPrefix")]
    public string? SourceAddressPrefix { get; set; }

    [JsonPropertyName("sourceAddressPrefixes")]
    public List<string>? SourceAddressPrefixes { get; set; }

    [JsonPropertyName("sourceApplicationSecurityGroups")]
    public List<ApplicationSecurityGroupModel>? SourceApplicationSecurityGroups { get; set; }

    [JsonPropertyName("sourcePortRange")]
    public string? SourcePortRange { get; set; }

    [JsonPropertyName("sourcePortRanges")]
    public List<string>? SourcePortRanges { get; set; }
}
