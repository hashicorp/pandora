using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Services;

internal class Definition : ResourceDefinition
{
    public string Name => "Services";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MoveCostConstant),
        typeof(PartitionSchemeConstant),
        typeof(ServiceCorrelationSchemeConstant),
        typeof(ServiceKindConstant),
        typeof(ServiceLoadMetricWeightConstant),
        typeof(ServicePackageActivationModeConstant),
        typeof(ServicePlacementPolicyTypeConstant),
        typeof(ServiceScalingMechanismKindConstant),
        typeof(ServiceScalingTriggerKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddRemoveIncrementalNamedPartitionScalingMechanismModel),
        typeof(AveragePartitionLoadScalingTriggerModel),
        typeof(AverageServiceLoadScalingTriggerModel),
        typeof(NamedPartitionSchemeModel),
        typeof(PartitionModel),
        typeof(PartitionInstanceCountScaleMechanismModel),
        typeof(ScalingMechanismModel),
        typeof(ScalingPolicyModel),
        typeof(ScalingTriggerModel),
        typeof(ServiceCorrelationModel),
        typeof(ServiceLoadMetricModel),
        typeof(ServicePlacementInvalidDomainPolicyModel),
        typeof(ServicePlacementNonPartiallyPlaceServicePolicyModel),
        typeof(ServicePlacementPolicyModel),
        typeof(ServicePlacementPreferPrimaryDomainPolicyModel),
        typeof(ServicePlacementRequireDomainDistributionPolicyModel),
        typeof(ServicePlacementRequiredDomainPolicyModel),
        typeof(ServiceResourceModel),
        typeof(ServiceResourcePropertiesModel),
        typeof(ServiceUpdateParametersModel),
        typeof(SingletonPartitionSchemeModel),
        typeof(StatefulServicePropertiesModel),
        typeof(StatelessServicePropertiesModel),
        typeof(SystemDataModel),
        typeof(UniformInt64RangePartitionSchemeModel),
    };
}
