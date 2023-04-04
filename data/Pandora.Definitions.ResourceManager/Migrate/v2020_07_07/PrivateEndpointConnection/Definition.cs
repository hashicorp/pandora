using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.PrivateEndpointConnection;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnection";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeletePrivateEndpointConnectionOperation(),
        new GetPrivateEndpointConnectionOperation(),
        new GetPrivateEndpointConnectionsOperation(),
        new PutPrivateEndpointConnectionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionCollectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ResourceIdModel),
    };
}
