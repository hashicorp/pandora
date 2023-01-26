using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.AvailableDelegations;

internal class Definition : ResourceDefinition
{
    public string Name => "AvailableDelegations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AvailableDelegationsListOperation(),
        new AvailableResourceGroupDelegationsListOperation(),
    };
}
