using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationRecoveryServicesProviders;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationRecoveryServicesProviders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByReplicationFabricsOperation(),
        new PurgeOperation(),
        new RefreshProviderOperation(),
    };
}
