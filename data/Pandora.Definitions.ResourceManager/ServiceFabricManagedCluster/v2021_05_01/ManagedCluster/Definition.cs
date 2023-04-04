using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedCluster";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessConstant),
        typeof(AddonFeaturesConstant),
        typeof(ClusterStateConstant),
        typeof(ClusterUpgradeCadenceConstant),
        typeof(ClusterUpgradeModeConstant),
        typeof(DirectionConstant),
        typeof(ManagedResourceProvisioningStateConstant),
        typeof(NsgProtocolConstant),
        typeof(ProbeProtocolConstant),
        typeof(ProtocolConstant),
        typeof(SkuNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationTypeVersionsCleanupPolicyModel),
        typeof(AzureActiveDirectoryModel),
        typeof(ClientCertificateModel),
        typeof(LoadBalancingRuleModel),
        typeof(ManagedClusterModel),
        typeof(ManagedClusterPropertiesModel),
        typeof(ManagedClusterUpdateParametersModel),
        typeof(NetworkSecurityRuleModel),
        typeof(SettingsParameterDescriptionModel),
        typeof(SettingsSectionDescriptionModel),
        typeof(SkuModel),
        typeof(SystemDataModel),
    };
}
