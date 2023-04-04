using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.MonitorsResource;

internal class Definition : ResourceDefinition
{
    public string Name => "MonitorsResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MonitorsCreateOperation(),
        new MonitorsDeleteOperation(),
        new MonitorsGetOperation(),
        new MonitorsListOperation(),
        new MonitorsListByResourceGroupOperation(),
        new MonitorsUpdateOperation(),
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
        typeof(DatadogMonitorResourceModel),
        typeof(DatadogMonitorResourceUpdateParametersModel),
        typeof(DatadogOrganizationPropertiesModel),
        typeof(IdentityPropertiesModel),
        typeof(MonitorPropertiesModel),
        typeof(MonitorUpdatePropertiesModel),
        typeof(ResourceSkuModel),
        typeof(UserInfoModel),
    };
}
