using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisions;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsRevisions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActivateRevisionOperation(),
        new DeactivateRevisionOperation(),
        new GetRevisionOperation(),
        new ListRevisionsOperation(),
        new RestartRevisionOperation(),
    };
}
