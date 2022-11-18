using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.Backups;

internal class Definition : ResourceDefinition
{
    public string Name => "Backups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountBackupsDeleteOperation(),
        new AccountBackupsGetOperation(),
        new AccountBackupsListOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetStatusOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
}
