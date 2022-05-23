using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IotCentral.v2021_11_01_preview.Networking;

internal class Definition : ResourceDefinition
{
    public string Name => "Networking";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateEndpointConnectionsCreateOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateLinksGetOperation(),
        new PrivateLinksListOperation(),
    };
}
