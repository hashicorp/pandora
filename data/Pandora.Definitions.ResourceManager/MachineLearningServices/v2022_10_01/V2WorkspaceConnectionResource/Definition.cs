using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.V2WorkspaceConnectionResource;

internal class Definition : ResourceDefinition
{
    public string Name => "V2WorkspaceConnectionResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkspaceConnectionsCreateOperation(),
        new WorkspaceConnectionsDeleteOperation(),
        new WorkspaceConnectionsGetOperation(),
        new WorkspaceConnectionsListOperation(),
    };
}
