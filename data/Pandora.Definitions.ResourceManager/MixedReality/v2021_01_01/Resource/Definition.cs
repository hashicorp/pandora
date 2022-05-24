using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Resource;

internal class Definition : ResourceDefinition
{
    public string Name => "Resource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RemoteRenderingAccountsCreateOperation(),
        new RemoteRenderingAccountsDeleteOperation(),
        new RemoteRenderingAccountsGetOperation(),
        new RemoteRenderingAccountsListByResourceGroupOperation(),
        new RemoteRenderingAccountsListBySubscriptionOperation(),
        new RemoteRenderingAccountsUpdateOperation(),
        new SpatialAnchorsAccountsCreateOperation(),
        new SpatialAnchorsAccountsDeleteOperation(),
        new SpatialAnchorsAccountsGetOperation(),
        new SpatialAnchorsAccountsListByResourceGroupOperation(),
        new SpatialAnchorsAccountsListBySubscriptionOperation(),
        new SpatialAnchorsAccountsUpdateOperation(),
    };
}
