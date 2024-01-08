using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCrossConnectionPeerings;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteCrossConnectionPeerings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant),
        typeof(ExpressRouteCircuitPeeringStateConstant),
        typeof(ExpressRoutePeeringStateConstant),
        typeof(ExpressRoutePeeringTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteCircuitPeeringConfigModel),
        typeof(ExpressRouteCrossConnectionPeeringModel),
        typeof(ExpressRouteCrossConnectionPeeringPropertiesModel),
        typeof(IPv6ExpressRouteCircuitPeeringConfigModel),
        typeof(SubResourceModel),
    };
}
