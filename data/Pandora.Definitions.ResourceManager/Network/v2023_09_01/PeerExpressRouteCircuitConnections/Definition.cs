using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.PeerExpressRouteCircuitConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "PeerExpressRouteCircuitConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CircuitConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PeerExpressRouteCircuitConnectionModel),
        typeof(PeerExpressRouteCircuitConnectionPropertiesFormatModel),
        typeof(SubResourceModel),
    };
}
