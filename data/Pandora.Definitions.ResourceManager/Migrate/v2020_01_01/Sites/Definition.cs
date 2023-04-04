using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.Sites;

internal class Definition : ResourceDefinition
{
    public string Name => "Sites";
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
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SiteAgentPropertiesModel),
        typeof(SiteHealthSummaryModel),
        typeof(SitePropertiesModel),
        typeof(SiteSpnPropertiesModel),
        typeof(VMwareSiteModel),
        typeof(VMwareSiteUsageModel),
    };
}
