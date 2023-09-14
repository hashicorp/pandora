using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SitesController;

internal class Definition : ResourceDefinition
{
    public string Name => "SitesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ComputeErrorSummaryOperation(),
        new ComputeusageOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new ExportApplicationsOperation(),
        new ExportMachineErrorsOperation(),
        new ExportMachinesOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListHealthSummaryOperation(),
        new SummaryOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiscoveryScopesConstant),
        typeof(ExportMachineErrorsPropertiesConstant),
        typeof(ProvisioningStateConstant),
        typeof(SiteHealthSummaryFabricLayoutUpdateSourcesItemConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiscoveryScopeErrorSummaryModel),
        typeof(ExportMachineErrorsRequestModel),
        typeof(ExportMachinesRequestModel),
        typeof(RequestExportMachineErrorsPropertiesModel),
        typeof(SiteAgentPropertiesModel),
        typeof(SiteErrorSummaryModel),
        typeof(SiteHealthSummaryModel),
        typeof(SiteHealthSummaryCollectionModel),
        typeof(SiteSpnPropertiesModel),
        typeof(SitesPropertiesModel),
        typeof(VMwareSiteModel),
        typeof(VMwareSiteUpdateModel),
        typeof(VMwareSiteUpdatePropertiesModel),
        typeof(VMwareSiteUsageModel),
    };
}
