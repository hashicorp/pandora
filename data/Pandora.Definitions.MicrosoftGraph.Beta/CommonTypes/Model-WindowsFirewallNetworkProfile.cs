// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsFirewallNetworkProfileModel
{
    [JsonPropertyName("authorizedApplicationRulesFromGroupPolicyMerged")]
    public bool? AuthorizedApplicationRulesFromGroupPolicyMerged { get; set; }

    [JsonPropertyName("authorizedApplicationRulesFromGroupPolicyNotMerged")]
    public bool? AuthorizedApplicationRulesFromGroupPolicyNotMerged { get; set; }

    [JsonPropertyName("connectionSecurityRulesFromGroupPolicyMerged")]
    public bool? ConnectionSecurityRulesFromGroupPolicyMerged { get; set; }

    [JsonPropertyName("connectionSecurityRulesFromGroupPolicyNotMerged")]
    public bool? ConnectionSecurityRulesFromGroupPolicyNotMerged { get; set; }

    [JsonPropertyName("firewallEnabled")]
    public StateManagementSettingConstant? FirewallEnabled { get; set; }

    [JsonPropertyName("globalPortRulesFromGroupPolicyMerged")]
    public bool? GlobalPortRulesFromGroupPolicyMerged { get; set; }

    [JsonPropertyName("globalPortRulesFromGroupPolicyNotMerged")]
    public bool? GlobalPortRulesFromGroupPolicyNotMerged { get; set; }

    [JsonPropertyName("inboundConnectionsBlocked")]
    public bool? InboundConnectionsBlocked { get; set; }

    [JsonPropertyName("inboundConnectionsRequired")]
    public bool? InboundConnectionsRequired { get; set; }

    [JsonPropertyName("inboundNotificationsBlocked")]
    public bool? InboundNotificationsBlocked { get; set; }

    [JsonPropertyName("inboundNotificationsRequired")]
    public bool? InboundNotificationsRequired { get; set; }

    [JsonPropertyName("incomingTrafficBlocked")]
    public bool? IncomingTrafficBlocked { get; set; }

    [JsonPropertyName("incomingTrafficRequired")]
    public bool? IncomingTrafficRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outboundConnectionsBlocked")]
    public bool? OutboundConnectionsBlocked { get; set; }

    [JsonPropertyName("outboundConnectionsRequired")]
    public bool? OutboundConnectionsRequired { get; set; }

    [JsonPropertyName("policyRulesFromGroupPolicyMerged")]
    public bool? PolicyRulesFromGroupPolicyMerged { get; set; }

    [JsonPropertyName("policyRulesFromGroupPolicyNotMerged")]
    public bool? PolicyRulesFromGroupPolicyNotMerged { get; set; }

    [JsonPropertyName("securedPacketExemptionAllowed")]
    public bool? SecuredPacketExemptionAllowed { get; set; }

    [JsonPropertyName("securedPacketExemptionBlocked")]
    public bool? SecuredPacketExemptionBlocked { get; set; }

    [JsonPropertyName("stealthModeBlocked")]
    public bool? StealthModeBlocked { get; set; }

    [JsonPropertyName("stealthModeRequired")]
    public bool? StealthModeRequired { get; set; }

    [JsonPropertyName("unicastResponsesToMulticastBroadcastsBlocked")]
    public bool? UnicastResponsesToMulticastBroadcastsBlocked { get; set; }

    [JsonPropertyName("unicastResponsesToMulticastBroadcastsRequired")]
    public bool? UnicastResponsesToMulticastBroadcastsRequired { get; set; }
}
