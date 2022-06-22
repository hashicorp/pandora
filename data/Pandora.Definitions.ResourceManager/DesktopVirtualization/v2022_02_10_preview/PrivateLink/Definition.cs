using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.PrivateLink;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLink";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateEndpointConnectionsDeleteByHostPoolOperation(),
        new PrivateEndpointConnectionsDeleteByWorkspaceOperation(),
        new PrivateEndpointConnectionsGetByHostPoolOperation(),
        new PrivateEndpointConnectionsGetByWorkspaceOperation(),
        new PrivateEndpointConnectionsListByHostPoolOperation(),
        new PrivateEndpointConnectionsListByWorkspaceOperation(),
        new PrivateEndpointConnectionsUpdateByHostPoolOperation(),
        new PrivateEndpointConnectionsUpdateByWorkspaceOperation(),
        new ResourcesListByHostPoolOperation(),
        new ResourcesListByWorkspaceOperation(),
    };
}
