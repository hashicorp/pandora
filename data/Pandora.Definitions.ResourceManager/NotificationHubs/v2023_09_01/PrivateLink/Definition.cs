using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.PrivateLink;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLink";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsGetGroupIdOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateEndpointConnectionsListGroupIdsOperation(),
        new PrivateEndpointConnectionsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateLinkConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionResourceModel),
        typeof(PrivateEndpointConnectionResourceListResultModel),
        typeof(PrivateLinkResourceModel),
        typeof(PrivateLinkResourceListResultModel),
        typeof(PrivateLinkResourcePropertiesModel),
        typeof(RemotePrivateEndpointConnectionModel),
        typeof(RemotePrivateLinkServiceConnectionStateModel),
    };
}
