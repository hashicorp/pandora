using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.NetworkManagerEffectiveConnectivityConfiguration;

internal class VirtualNetworkId : ResourceID
{
    public string? CommonAlias => "VirtualNetwork";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.Network"),
        ResourceIDSegment.Static("virtualNetworks", "virtualNetworks"),
        ResourceIDSegment.UserSpecified("virtualNetworkName"),
    };
}
