using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebAppSitesController;

internal class Definition : ResourceDefinition
{
    public string Name => "WebAppSitesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ErrorSummaryOperation(),
        new ExportInventoryOperation(),
        new GetOperation(),
        new ListByMasterSiteOperation(),
        new RefreshOperation(),
        new SummaryOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiscoveryScopesConstant),
        typeof(ProvisioningStateConstant),
        typeof(WebAppSitePropertiesDiscoveryScenarioConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiscoveryScopeErrorSummaryModel),
        typeof(ErrorSummaryRequestModel),
        typeof(ExportWebAppsRequestModel),
        typeof(ProxySiteRefreshBodyModel),
        typeof(SiteAgentPropertiesModel),
        typeof(SiteAppliancePropertiesModel),
        typeof(SiteErrorSummaryModel),
        typeof(SiteSpnPropertiesModel),
        typeof(WebAppSiteModel),
        typeof(WebAppSitePropertiesModel),
        typeof(WebAppSiteUpdateModel),
        typeof(WebAppSiteUpdatePropertiesModel),
        typeof(WebAppSiteUsageModel),
    };
}
