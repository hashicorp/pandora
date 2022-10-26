using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01.LoadTest;

internal class Definition : ResourceDefinition
{
    public string Name => "LoadTest";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOutboundNetworkDependenciesEndpointsOperation(),
    };
}
