using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimes;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationRuntimes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateLinkedIntegrationRuntimeOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetConnectionInfoOperation(),
        new GetMonitoringDataOperation(),
        new GetStatusOperation(),
        new ListAuthKeysOperation(),
        new ListByFactoryOperation(),
        new ListOutboundNetworkDependenciesEndpointsOperation(),
        new RegenerateAuthKeyOperation(),
        new RemoveLinksOperation(),
        new StartOperation(),
        new StopOperation(),
        new SyncCredentialsOperation(),
        new UpdateOperation(),
        new UpgradeOperation(),
    };
}
