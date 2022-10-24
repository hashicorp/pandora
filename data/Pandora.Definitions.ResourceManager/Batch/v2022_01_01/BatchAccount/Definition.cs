using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.BatchAccount;

internal class Definition : ResourceDefinition
{
    public string Name => "BatchAccount";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetKeysOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListOutboundNetworkDependenciesEndpointsOperation(),
        new RegenerateKeyOperation(),
        new SynchronizeAutoStorageKeysOperation(),
        new UpdateOperation(),
    };
}
