using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationRuntime";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AuthKeysListOperation(),
        new AuthKeysRegenerateOperation(),
        new ConnectionInfosGetOperation(),
        new CreateOperation(),
        new CredentialsSyncOperation(),
        new DeleteOperation(),
        new DisableInteractiveQueryOperation(),
        new EnableInteractiveQueryOperation(),
        new GetOperation(),
        new ListByWorkspaceOperation(),
        new MonitoringDataListOperation(),
        new NodeIPAddressGetOperation(),
        new NodesDeleteOperation(),
        new NodesGetOperation(),
        new NodesUpdateOperation(),
        new ObjectMetadataListOperation(),
        new ObjectMetadataRefreshOperation(),
        new StartOperation(),
        new StatusGetOperation(),
        new StopOperation(),
        new UpdateOperation(),
        new UpgradeOperation(),
    };
}
