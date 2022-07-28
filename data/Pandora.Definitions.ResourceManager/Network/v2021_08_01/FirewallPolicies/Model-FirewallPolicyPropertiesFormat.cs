using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.FirewallPolicies;


internal class FirewallPolicyPropertiesFormatModel
{
    [JsonPropertyName("basePolicy")]
    public SubResourceModel? BasePolicy { get; set; }

    [JsonPropertyName("childPolicies")]
    public List<SubResourceModel>? ChildPolicies { get; set; }

    [JsonPropertyName("dnsSettings")]
    public DnsSettingsModel? DnsSettings { get; set; }

    [JsonPropertyName("explicitProxySettings")]
    public ExplicitProxySettingsModel? ExplicitProxySettings { get; set; }

    [JsonPropertyName("firewalls")]
    public List<SubResourceModel>? Firewalls { get; set; }

    [JsonPropertyName("insights")]
    public FirewallPolicyInsightsModel? Insights { get; set; }

    [JsonPropertyName("intrusionDetection")]
    public FirewallPolicyIntrusionDetectionModel? IntrusionDetection { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("ruleCollectionGroups")]
    public List<SubResourceModel>? RuleCollectionGroups { get; set; }

    [JsonPropertyName("sku")]
    public FirewallPolicySkuModel? Sku { get; set; }

    [JsonPropertyName("snat")]
    public FirewallPolicySNATModel? Snat { get; set; }

    [JsonPropertyName("sql")]
    public FirewallPolicySQLModel? Sql { get; set; }

    [JsonPropertyName("threatIntelMode")]
    public AzureFirewallThreatIntelModeConstant? ThreatIntelMode { get; set; }

    [JsonPropertyName("threatIntelWhitelist")]
    public FirewallPolicyThreatIntelWhitelistModel? ThreatIntelWhitelist { get; set; }

    [JsonPropertyName("transportSecurity")]
    public FirewallPolicyTransportSecurityModel? TransportSecurity { get; set; }
}
