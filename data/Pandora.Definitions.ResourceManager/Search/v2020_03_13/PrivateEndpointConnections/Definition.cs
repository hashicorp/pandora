using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.PrivateEndpointConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new ListByServiceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdminKeyKindConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionPropertiesPrivateEndpointModel),
        typeof(PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionStateModel),
    };
}
