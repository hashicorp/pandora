using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlSitesController;

internal class Definition : ResourceDefinition
{
    public string Name => "SqlSitesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ErrorSummaryOperation(),
        new ExportSqlServerErrorsOperation(),
        new ExportSqlServersOperation(),
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
        typeof(SqlSitePropertiesDiscoveryScenarioConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiscoveryScopeErrorSummaryModel),
        typeof(ErrorSummaryRequestModel),
        typeof(ExportSqlServersRequestModel),
        typeof(SiteAgentPropertiesModel),
        typeof(SiteAppliancePropertiesModel),
        typeof(SiteErrorSummaryModel),
        typeof(SiteSpnPropertiesModel),
        typeof(SqlSiteModel),
        typeof(SqlSitePropertiesModel),
        typeof(SqlSiteRefreshBodyModel),
        typeof(SqlSiteUpdateModel),
        typeof(SqlSiteUpdatePropertiesModel),
        typeof(SqlSiteUsageModel),
    };
}
