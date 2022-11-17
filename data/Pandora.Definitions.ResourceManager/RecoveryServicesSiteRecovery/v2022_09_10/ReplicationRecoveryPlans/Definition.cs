using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryPlans;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationRecoveryPlans";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new FailoverCancelOperation(),
        new FailoverCommitOperation(),
        new GetOperation(),
        new ListOperation(),
        new PlannedFailoverOperation(),
        new ReprotectOperation(),
        new TestFailoverOperation(),
        new TestFailoverCleanupOperation(),
        new UnplannedFailoverOperation(),
        new UpdateOperation(),
    };
}
