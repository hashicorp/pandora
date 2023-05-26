using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.NetworkManagerConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkManagerConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ManagementGroupNetworkManagerConnectionsCreateOrUpdateOperation(),
        new ManagementGroupNetworkManagerConnectionsDeleteOperation(),
        new ManagementGroupNetworkManagerConnectionsGetOperation(),
        new ManagementGroupNetworkManagerConnectionsListOperation(),
        new SubscriptionNetworkManagerConnectionsCreateOrUpdateOperation(),
        new SubscriptionNetworkManagerConnectionsDeleteOperation(),
        new SubscriptionNetworkManagerConnectionsGetOperation(),
        new SubscriptionNetworkManagerConnectionsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ScopeConnectionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NetworkManagerConnectionModel),
        typeof(NetworkManagerConnectionPropertiesModel),
    };
}
