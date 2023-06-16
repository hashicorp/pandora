using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2023_07_01.PrivateEndpointConnectionProxies;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnectionProxies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ListByAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionProxyProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionDetailsModel),
        typeof(GroupConnectivityInformationModel),
        typeof(PrivateEndpointConnectionProxyModel),
        typeof(PrivateEndpointConnectionProxyListResultModel),
        typeof(PrivateEndpointConnectionProxyPropertiesModel),
        typeof(PrivateLinkServiceConnectionModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(PrivateLinkServiceProxyModel),
        typeof(RemotePrivateEndpointModel),
        typeof(RemotePrivateEndpointConnectionModel),
    };
}
