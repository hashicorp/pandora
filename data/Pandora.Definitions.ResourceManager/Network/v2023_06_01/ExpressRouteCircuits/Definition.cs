using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.ExpressRouteCircuits;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteCircuits";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthorizationUseStatusConstant),
        typeof(CircuitConnectionStatusConstant),
        typeof(ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant),
        typeof(ExpressRouteCircuitPeeringStateConstant),
        typeof(ExpressRouteCircuitSkuFamilyConstant),
        typeof(ExpressRouteCircuitSkuTierConstant),
        typeof(ExpressRoutePeeringStateConstant),
        typeof(ExpressRoutePeeringTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ServiceProviderProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizationPropertiesFormatModel),
        typeof(ExpressRouteCircuitModel),
        typeof(ExpressRouteCircuitAuthorizationModel),
        typeof(ExpressRouteCircuitConnectionModel),
        typeof(ExpressRouteCircuitConnectionPropertiesFormatModel),
        typeof(ExpressRouteCircuitPeeringModel),
        typeof(ExpressRouteCircuitPeeringConfigModel),
        typeof(ExpressRouteCircuitPeeringPropertiesFormatModel),
        typeof(ExpressRouteCircuitPropertiesFormatModel),
        typeof(ExpressRouteCircuitServiceProviderPropertiesModel),
        typeof(ExpressRouteCircuitSkuModel),
        typeof(ExpressRouteCircuitStatsModel),
        typeof(ExpressRouteConnectionIdModel),
        typeof(IPv6CircuitConnectionConfigModel),
        typeof(IPv6ExpressRouteCircuitPeeringConfigModel),
        typeof(PeerExpressRouteCircuitConnectionModel),
        typeof(PeerExpressRouteCircuitConnectionPropertiesFormatModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
