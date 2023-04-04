using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "ProviderInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SslPreferenceConstant),
        typeof(WorkloadMonitorProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DB2ProviderInstancePropertiesModel),
        typeof(ErrorModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(ErrorInnerErrorModel),
        typeof(HanaDbProviderInstancePropertiesModel),
        typeof(MsSqlServerProviderInstancePropertiesModel),
        typeof(OperationStatusResultModel),
        typeof(PrometheusHaClusterProviderInstancePropertiesModel),
        typeof(PrometheusOSProviderInstancePropertiesModel),
        typeof(ProviderInstanceModel),
        typeof(ProviderInstancePropertiesModel),
        typeof(ProviderSpecificPropertiesModel),
        typeof(SapNetWeaverProviderInstancePropertiesModel),
    };
}
