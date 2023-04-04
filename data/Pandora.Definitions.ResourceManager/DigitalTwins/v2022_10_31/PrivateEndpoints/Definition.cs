using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2022_10_31.PrivateEndpoints;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateEndpointConnectionsCreateOrUpdateOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateLinkResourcesGetOperation(),
        new PrivateLinkResourcesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionPropertiesProvisioningStateConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionPropertiesModel),
        typeof(ConnectionStateModel),
        typeof(GroupIdInformationModel),
        typeof(GroupIdInformationPropertiesModel),
        typeof(GroupIdInformationResponseModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionsResponseModel),
    };
}
