using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.OutboundNetworkDependenciesEndpoints;

internal class Definition : ResourceDefinition
{
    public string Name => "OutboundNetworkDependenciesEndpoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClustersListOutboundNetworkDependenciesEndpointsOperation(),
    };
}
