using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVSites;

internal class Definition : ResourceDefinition
{
    public string Name => "HyperVSites";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteSiteOperation(),
        new GetSiteOperation(),
        new GetSiteHealthSummaryOperation(),
        new GetSiteUsageOperation(),
        new PatchSiteOperation(),
        new PutSiteOperation(),
        new RefreshSiteOperation(),
    };
}
