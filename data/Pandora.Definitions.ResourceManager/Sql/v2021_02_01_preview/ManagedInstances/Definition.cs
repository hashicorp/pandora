using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FailoverOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByInstancePoolOperation(),
        new ListByManagedInstanceOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdministratorTypeConstant),
        typeof(AggregationFunctionTypeConstant),
        typeof(ManagedInstanceLicenseTypeConstant),
        typeof(ManagedInstanceProxyOverrideConstant),
        typeof(ManagedServerCreateModeConstant),
        typeof(MetricTypeConstant),
        typeof(PrincipalTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(QueryMetricUnitTypeConstant),
        typeof(QueryTimeGrainTypeConstant),
        typeof(ReplicaTypeConstant),
        typeof(StorageAccountTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceModel),
        typeof(ManagedInstanceExternalAdministratorModel),
        typeof(ManagedInstancePecPropertyModel),
        typeof(ManagedInstancePrivateEndpointConnectionPropertiesModel),
        typeof(ManagedInstancePrivateEndpointPropertyModel),
        typeof(ManagedInstancePrivateLinkServiceConnectionStatePropertyModel),
        typeof(ManagedInstancePropertiesModel),
        typeof(ManagedInstanceUpdateModel),
        typeof(QueryMetricIntervalModel),
        typeof(QueryMetricPropertiesModel),
        typeof(QueryStatisticsPropertiesModel),
        typeof(SkuModel),
        typeof(TopQueriesModel),
    };
}
