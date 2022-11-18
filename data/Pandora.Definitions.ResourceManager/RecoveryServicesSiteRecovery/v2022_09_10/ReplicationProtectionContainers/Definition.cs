using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectionContainers;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationProtectionContainers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new DiscoverProtectableItemOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationFabricsOperation(),
        new SwitchProtectionOperation(),
    };
}
