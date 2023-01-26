using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkManagerConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SubscriptionNetworkManagerConnectionsCreateOrUpdateOperation(),
        new SubscriptionNetworkManagerConnectionsDeleteOperation(),
        new SubscriptionNetworkManagerConnectionsGetOperation(),
        new SubscriptionNetworkManagerConnectionsListOperation(),
    };
}
