using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCrossConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteCrossConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateConstant),
        typeof(ExpressRouteCircuitPeeringStateConstant),
        typeof(ExpressRoutePeeringStateConstant),
        typeof(ExpressRoutePeeringTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ServiceProviderProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteCircuitPeeringConfigModel),
        typeof(ExpressRouteCircuitReferenceModel),
        typeof(ExpressRouteCrossConnectionModel),
        typeof(ExpressRouteCrossConnectionPeeringModel),
        typeof(ExpressRouteCrossConnectionPeeringPropertiesModel),
        typeof(ExpressRouteCrossConnectionPropertiesModel),
        typeof(IPv6ExpressRouteCircuitPeeringConfigModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
