using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "ExpressRouteGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(VnetLocalRouteOverrideCriteriaConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpressRouteCircuitPeeringIdModel),
        typeof(ExpressRouteConnectionModel),
        typeof(ExpressRouteConnectionPropertiesModel),
        typeof(ExpressRouteGatewayModel),
        typeof(ExpressRouteGatewayListModel),
        typeof(ExpressRouteGatewayPropertiesModel),
        typeof(ExpressRouteGatewayPropertiesAutoScaleConfigurationModel),
        typeof(ExpressRouteGatewayPropertiesAutoScaleConfigurationBoundsModel),
        typeof(PropagatedRouteTableModel),
        typeof(RoutingConfigurationModel),
        typeof(StaticRouteModel),
        typeof(StaticRoutesConfigModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(VirtualHubIdModel),
        typeof(VnetRouteModel),
    };
}
