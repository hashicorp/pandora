using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VpnLinkConnections;

internal class VpnLinkConnectionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{vpnGatewayName}/vpnConnections/{vpnConnectionName}/vpnLinkConnections/{vpnLinkConnectionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftNetwork", "Microsoft.Network"),
        ResourceIDSegment.Static("staticVpnGateways", "vpnGateways"),
        ResourceIDSegment.UserSpecified("vpnGatewayName"),
        ResourceIDSegment.Static("staticVpnConnections", "vpnConnections"),
        ResourceIDSegment.UserSpecified("vpnConnectionName"),
        ResourceIDSegment.Static("staticVpnLinkConnections", "vpnLinkConnections"),
        ResourceIDSegment.UserSpecified("vpnLinkConnectionName"),
    };
}
