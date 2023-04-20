using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Application;

internal class Definition : ResourceDefinition
{
    public string Name => "Application";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ArmUpgradeFailureActionConstant),
        typeof(RollingUpgradeModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationMetricDescriptionModel),
        typeof(ApplicationResourceModel),
        typeof(ApplicationResourceListModel),
        typeof(ApplicationResourcePropertiesModel),
        typeof(ApplicationResourceUpdateModel),
        typeof(ApplicationResourceUpdatePropertiesModel),
        typeof(ApplicationUpgradePolicyModel),
        typeof(ApplicationUserAssignedIdentityModel),
        typeof(ArmApplicationHealthPolicyModel),
        typeof(ArmRollingUpgradeMonitoringPolicyModel),
        typeof(ArmServiceTypeHealthPolicyModel),
        typeof(SystemDataModel),
    };
}
