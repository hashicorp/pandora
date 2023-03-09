using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Configurations;

internal class Definition : ResourceDefinition
{
    public string Name => "Configurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateCoordinatorOperation(),
        new CreateOrUpdateNodeOperation(),
        new GetOperation(),
        new GetCoordinatorOperation(),
        new GetNodeOperation(),
        new ListByClusterOperation(),
        new ListByServerOperation(),
    };
}
