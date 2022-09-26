using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.RestorePoints;

internal class Definition : ResourceDefinition
{
    public string Name => "RestorePoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RestorePointsCreateOperation(),
        new RestorePointsDeleteOperation(),
        new RestorePointsGetOperation(),
    };
}
