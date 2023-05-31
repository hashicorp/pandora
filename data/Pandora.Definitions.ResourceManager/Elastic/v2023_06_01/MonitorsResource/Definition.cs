using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.MonitorsResource;

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
        typeof(MonitoringStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CompanyInfoModel),
        typeof(ElasticCloudDeploymentModel),
        typeof(ElasticCloudUserModel),
        typeof(ElasticMonitorResourceModel),
        typeof(ElasticMonitorResourceUpdateParametersModel),
        typeof(ElasticPropertiesModel),
        typeof(MonitorPropertiesModel),
        typeof(ResourceSkuModel),
        typeof(UserInfoModel),
    };
}
