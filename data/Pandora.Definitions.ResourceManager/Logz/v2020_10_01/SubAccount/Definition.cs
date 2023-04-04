using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.SubAccount;

internal class Definition : ResourceDefinition
{
    public string Name => "SubAccount";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListMonitoredResourcesOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LiftrResourceCategoriesConstant),
        typeof(ManagedIdentityTypesConstant),
        typeof(MarketplaceSubscriptionStatusConstant),
        typeof(MonitoringStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IdentityPropertiesModel),
        typeof(LogzMonitorResourceModel),
        typeof(LogzMonitorResourceUpdateParametersModel),
        typeof(LogzOrganizationPropertiesModel),
        typeof(MonitorPropertiesModel),
        typeof(MonitorUpdatePropertiesModel),
        typeof(MonitoredResourceModel),
        typeof(PlanDataModel),
        typeof(UserInfoModel),
    };
}
