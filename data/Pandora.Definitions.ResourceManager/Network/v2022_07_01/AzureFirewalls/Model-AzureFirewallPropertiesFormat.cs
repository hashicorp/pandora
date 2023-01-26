using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.AzureFirewalls;


internal class AzureFirewallPropertiesFormatModel
{
    [JsonPropertyName("additionalProperties")]
    public Dictionary<string, string>? AdditionalProperties { get; set; }

    [JsonPropertyName("applicationRuleCollections")]
    public List<AzureFirewallApplicationRuleCollectionModel>? ApplicationRuleCollections { get; set; }

    [JsonPropertyName("firewallPolicy")]
    public SubResourceModel? FirewallPolicy { get; set; }

    [JsonPropertyName("hubIPAddresses")]
    public HubIPAddressesModel? HubIPAddresses { get; set; }

    [JsonPropertyName("ipConfigurations")]
    public List<AzureFirewallIPConfigurationModel>? IPConfigurations { get; set; }

    [JsonPropertyName("ipGroups")]
    public List<AzureFirewallIPGroupsModel>? IPGroups { get; set; }

    [JsonPropertyName("managementIpConfiguration")]
    public AzureFirewallIPConfigurationModel? ManagementIPConfiguration { get; set; }

    [JsonPropertyName("natRuleCollections")]
    public List<AzureFirewallNatRuleCollectionModel>? NatRuleCollections { get; set; }

    [JsonPropertyName("networkRuleCollections")]
    public List<AzureFirewallNetworkRuleCollectionModel>? NetworkRuleCollections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sku")]
    public AzureFirewallSkuModel? Sku { get; set; }

    [JsonPropertyName("threatIntelMode")]
    public AzureFirewallThreatIntelModeConstant? ThreatIntelMode { get; set; }

    [JsonPropertyName("virtualHub")]
    public SubResourceModel? VirtualHub { get; set; }
}
