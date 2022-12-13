using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.TenantBackfill;

internal class Definition : ResourceDefinition
{
    public string Name => "TenantBackfill";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new StartTenantBackfillOperation(),
        new StatusOperation(),
    };
}
