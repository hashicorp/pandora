using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.RouteFilters;

internal class Definition : ResourceDefinition
{
    public string Name => "RouteFilters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessConstant),
        typeof(CircuitConnectionStatusConstant),
        typeof(ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant),
        typeof(ExpressRouteCircuitPeeringStateConstant),
        typeof(ExpressRoutePeeringStateConstant),
        typeof(ExpressRoutePeeringTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(RouteFilterRuleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteCircuitConnectionModel),
        typeof(ExpressRouteCircuitConnectionPropertiesFormatModel),
        typeof(ExpressRouteCircuitPeeringModel),
        typeof(ExpressRouteCircuitPeeringConfigModel),
        typeof(ExpressRouteCircuitPeeringPropertiesFormatModel),
        typeof(ExpressRouteCircuitStatsModel),
        typeof(ExpressRouteConnectionIdModel),
        typeof(IPv6CircuitConnectionConfigModel),
        typeof(IPv6ExpressRouteCircuitPeeringConfigModel),
        typeof(PeerExpressRouteCircuitConnectionModel),
        typeof(PeerExpressRouteCircuitConnectionPropertiesFormatModel),
        typeof(RouteFilterModel),
        typeof(RouteFilterPropertiesFormatModel),
        typeof(RouteFilterRuleModel),
        typeof(RouteFilterRulePropertiesFormatModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
