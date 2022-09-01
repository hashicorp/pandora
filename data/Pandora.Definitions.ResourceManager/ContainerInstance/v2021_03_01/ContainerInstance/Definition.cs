using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_03_01.ContainerInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerInstance";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContainerGroupsCreateOrUpdateOperation(),
        new ContainerGroupsDeleteOperation(),
        new ContainerGroupsGetOperation(),
        new ContainerGroupsListOperation(),
        new ContainerGroupsListByResourceGroupOperation(),
        new ContainerGroupsRestartOperation(),
        new ContainerGroupsStartOperation(),
        new ContainerGroupsStopOperation(),
        new ContainerGroupsUpdateOperation(),
        new ContainersAttachOperation(),
        new ContainersExecuteCommandOperation(),
        new ContainersListLogsOperation(),
        new LocationListCachedImagesOperation(),
        new LocationListCapabilitiesOperation(),
        new LocationListUsageOperation(),
    };
}
