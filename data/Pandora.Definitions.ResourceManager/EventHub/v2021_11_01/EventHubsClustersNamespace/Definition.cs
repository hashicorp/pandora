using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClustersNamespace;

internal class Definition : ResourceDefinition
{
    public string Name => "EventHubsClustersNamespace";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClustersListNamespacesOperation(),
    };
}
