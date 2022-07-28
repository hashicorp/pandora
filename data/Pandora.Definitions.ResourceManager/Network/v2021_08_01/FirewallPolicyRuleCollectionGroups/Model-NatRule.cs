using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.FirewallPolicyRuleCollectionGroups;

[ValueForType("NatRule")]
internal class NatRuleModel : FirewallPolicyRuleModel
{
    [JsonPropertyName("destinationAddresses")]
    public List<string>? DestinationAddresses { get; set; }

    [JsonPropertyName("destinationPorts")]
    public List<string>? DestinationPorts { get; set; }

    [JsonPropertyName("ipProtocols")]
    public List<FirewallPolicyRuleNetworkProtocolConstant>? IPProtocols { get; set; }

    [JsonPropertyName("sourceAddresses")]
    public List<string>? SourceAddresses { get; set; }

    [JsonPropertyName("sourceIpGroups")]
    public List<string>? SourceIPGroups { get; set; }

    [JsonPropertyName("translatedAddress")]
    public string? TranslatedAddress { get; set; }

    [JsonPropertyName("translatedFqdn")]
    public string? TranslatedFqdn { get; set; }

    [JsonPropertyName("translatedPort")]
    public string? TranslatedPort { get; set; }
}
