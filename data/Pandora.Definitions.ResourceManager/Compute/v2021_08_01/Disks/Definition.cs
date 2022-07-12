using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Disks;

internal class Definition : ResourceDefinition
{
    public string Name => "Disks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GrantAccessOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RevokeAccessOperation(),
        new UpdateOperation(),
    };
}
