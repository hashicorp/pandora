using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.MHSMListPrivateEndpointConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "MHSMListPrivateEndpointConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MHSMPrivateEndpointConnectionsListByResourceOperation(),
    };
}
