using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCircuitPeerings;

internal class ExpressRouteCircuitPeeringId : ResourceID
{
    public string? CommonAlias => "ExpressRouteCircuitPeering";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/expressRouteCircuits/{expressRouteCircuitName}/peerings/{peeringName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.Network"),
        ResourceIDSegment.Static("expressRouteCircuits", "expressRouteCircuits"),
        ResourceIDSegment.UserSpecified("expressRouteCircuitName"),
        ResourceIDSegment.Static("peerings", "peerings"),
        ResourceIDSegment.UserSpecified("peeringName"),
    };
}
