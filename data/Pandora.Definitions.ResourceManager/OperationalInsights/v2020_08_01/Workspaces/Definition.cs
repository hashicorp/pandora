using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Workspaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GatewaysDeleteOperation(),
        new GetOperation(),
        new IntelligencePacksDisableOperation(),
        new IntelligencePacksEnableOperation(),
        new IntelligencePacksListOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ManagementGroupsListOperation(),
        new SchemaGetOperation(),
        new SharedKeysGetSharedKeysOperation(),
        new SharedKeysRegenerateOperation(),
        new UpdateOperation(),
        new UsagesListOperation(),
        new WorkspacePurgeGetPurgeStatusOperation(),
        new WorkspacePurgePurgeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataIngestionStatusConstant),
        typeof(PublicNetworkAccessTypeConstant),
        typeof(PurgeStateConstant),
        typeof(SearchSortEnumConstant),
        typeof(WorkspaceEntityStatusConstant),
        typeof(WorkspaceSkuNameEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CoreSummaryModel),
        typeof(IntelligencePackModel),
        typeof(ManagementGroupModel),
        typeof(ManagementGroupPropertiesModel),
        typeof(MetricNameModel),
        typeof(PrivateLinkScopedResourceModel),
        typeof(SearchGetSchemaResponseModel),
        typeof(SearchMetadataModel),
        typeof(SearchMetadataSchemaModel),
        typeof(SearchSchemaValueModel),
        typeof(SearchSortModel),
        typeof(SharedKeysModel),
        typeof(UsageMetricModel),
        typeof(WorkspaceModel),
        typeof(WorkspaceCappingModel),
        typeof(WorkspaceListManagementGroupsResultModel),
        typeof(WorkspaceListResultModel),
        typeof(WorkspaceListUsagesResultModel),
        typeof(WorkspacePatchModel),
        typeof(WorkspacePropertiesModel),
        typeof(WorkspacePurgeBodyModel),
        typeof(WorkspacePurgeBodyFiltersModel),
        typeof(WorkspacePurgeResponseModel),
        typeof(WorkspacePurgeStatusResponseModel),
        typeof(WorkspaceSkuModel),
    };
}
