using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.DELETE;

internal class Definition : ResourceDefinition
{
    public string Name => "DELETE";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateEndpointConnectionsDeleteOperation(),
    };
}
