using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Disks;

internal class Definition : ResourceDefinition
{
    public string Name => "Disks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AttachOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DetachOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
}
