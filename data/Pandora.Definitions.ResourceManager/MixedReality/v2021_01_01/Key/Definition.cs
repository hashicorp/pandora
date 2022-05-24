using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Key;

internal class Definition : ResourceDefinition
{
    public string Name => "Key";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RemoteRenderingAccountsListKeysOperation(),
        new RemoteRenderingAccountsRegenerateKeysOperation(),
        new SpatialAnchorsAccountsListKeysOperation(),
        new SpatialAnchorsAccountsRegenerateKeysOperation(),
    };
}
