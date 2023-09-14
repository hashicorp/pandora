using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MasterSitesController;

internal class Definition : ResourceDefinition
{
    public string Name => "MasterSitesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ErrorSummaryOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiscoveryScopesConstant),
        typeof(MasterSitePropertiesPublicNetworkAccessConstant),
        typeof(PrivateLinkServiceConnectionStateStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiscoveryScopeErrorSummaryModel),
        typeof(ErrorSummaryRequestModel),
        typeof(MasterSiteModel),
        typeof(MasterSitePropertiesModel),
        typeof(MasterSiteUpdateModel),
        typeof(MasterSiteUpdatePropertiesModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesV2Model),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ResourceIdModel),
        typeof(SiteErrorSummaryModel),
    };
}
