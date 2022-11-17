using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationFabrics;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationFabrics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckConsistencyOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new MigrateToAadOperation(),
        new PurgeOperation(),
        new ReassociateGatewayOperation(),
        new RenewCertificateOperation(),
    };
}
