using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedClusterVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedClusterVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetByEnvironmentOperation(),
        new ListOperation(),
        new ListByEnvironmentOperation(),
    };
}
