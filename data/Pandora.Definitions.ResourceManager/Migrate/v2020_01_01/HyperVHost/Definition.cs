using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.HyperVHost;

internal class Definition : ResourceDefinition
{
    public string Name => "HyperVHost";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetAllHostsInSiteOperation(),
        new GetHostOperation(),
        new PutHostOperation(),
    };
}
