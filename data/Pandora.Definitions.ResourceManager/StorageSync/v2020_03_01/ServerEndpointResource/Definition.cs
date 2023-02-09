using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;

internal class Definition : ResourceDefinition
{
    public string Name => "ServerEndpointResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServerEndpointsCreateOperation(),
        new ServerEndpointsDeleteOperation(),
        new ServerEndpointsGetOperation(),
        new ServerEndpointsListBySyncGroupOperation(),
        new ServerEndpointsUpdateOperation(),
        new ServerEndpointsrecallActionOperation(),
    };
}
