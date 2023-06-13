using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstancePrivateEndpointConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedInstancePrivateEndpointConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByManagedInstanceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstancePrivateEndpointConnectionModel),
        typeof(ManagedInstancePrivateEndpointConnectionPropertiesModel),
        typeof(ManagedInstancePrivateEndpointPropertyModel),
        typeof(ManagedInstancePrivateLinkServiceConnectionStatePropertyModel),
    };
}
