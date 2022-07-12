using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.DiskAccesses;

internal class Definition : ResourceDefinition
{
    public string Name => "DiskAccesses";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DeleteAPrivateEndpointConnectionOperation(),
        new GetOperation(),
        new GetAPrivateEndpointConnectionOperation(),
        new GetPrivateLinkResourcesOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListPrivateEndpointConnectionsOperation(),
        new UpdateOperation(),
        new UpdateAPrivateEndpointConnectionOperation(),
    };
}
