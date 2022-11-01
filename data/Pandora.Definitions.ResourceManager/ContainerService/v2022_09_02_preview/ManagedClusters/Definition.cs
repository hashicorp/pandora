using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AbortLatestOperationOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAccessProfileOperation(),
        new GetCommandResultOperation(),
        new GetOSOptionsOperation(),
        new GetUpgradeProfileOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListClusterAdminCredentialsOperation(),
        new ListClusterMonitoringUserCredentialsOperation(),
        new ListClusterUserCredentialsOperation(),
        new ListOutboundNetworkDependenciesEndpointsOperation(),
        new ResetAADProfileOperation(),
        new ResetServicePrincipalProfileOperation(),
        new RotateClusterCertificatesOperation(),
        new RotateServiceAccountSigningKeysOperation(),
        new RunCommandOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateTagsOperation(),
    };
}
