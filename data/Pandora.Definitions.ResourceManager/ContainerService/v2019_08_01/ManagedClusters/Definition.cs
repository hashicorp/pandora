using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.ManagedClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAccessProfileOperation(),
        new GetUpgradeProfileOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListClusterAdminCredentialsOperation(),
        new ListClusterUserCredentialsOperation(),
        new ResetAADProfileOperation(),
        new ResetServicePrincipalProfileOperation(),
        new RotateClusterCertificatesOperation(),
        new UpdateTagsOperation(),
    };
}
