using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Service;

internal class Definition : ResourceDefinition
{
    public string Name => "Service";
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
        typeof(ArmServicePackageActivationModeConstant),
        typeof(MoveCostConstant),
        typeof(PartitionSchemeConstant),
        typeof(ServiceCorrelationSchemeConstant),
        typeof(ServiceKindConstant),
        typeof(ServiceLoadMetricWeightConstant),
        typeof(ServicePlacementPolicyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NamedPartitionSchemeDescriptionModel),
        typeof(PartitionSchemeDescriptionModel),
        typeof(ServiceCorrelationDescriptionModel),
        typeof(ServiceLoadMetricDescriptionModel),
        typeof(ServicePlacementPolicyDescriptionModel),
        typeof(ServiceResourceModel),
        typeof(ServiceResourceListModel),
        typeof(ServiceResourcePropertiesModel),
        typeof(ServiceResourceUpdateModel),
        typeof(ServiceResourceUpdatePropertiesModel),
        typeof(SingletonPartitionSchemeDescriptionModel),
        typeof(StatefulServicePropertiesModel),
        typeof(StatefulServiceUpdatePropertiesModel),
        typeof(StatelessServicePropertiesModel),
        typeof(StatelessServiceUpdatePropertiesModel),
        typeof(SystemDataModel),
        typeof(UniformInt64RangePartitionSchemeDescriptionModel),
    };
}
