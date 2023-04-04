using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;

internal class Definition : ResourceDefinition
{
    public string Name => "Cluster";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AddOnFeaturesConstant),
        typeof(ClusterStateConstant),
        typeof(ClusterUpgradeCadenceConstant),
        typeof(ClusterVersionsEnvironmentConstant),
        typeof(DurabilityLevelConstant),
        typeof(EnvironmentConstant),
        typeof(NotificationCategoryConstant),
        typeof(NotificationChannelConstant),
        typeof(NotificationLevelConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReliabilityLevelConstant),
        typeof(SfZonalUpgradeModeConstant),
        typeof(UpgradeModeConstant),
        typeof(VMSSZonalUpgradeModeConstant),
        typeof(X509StoreNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationDeltaHealthPolicyModel),
        typeof(ApplicationHealthPolicyModel),
        typeof(ApplicationTypeVersionsCleanupPolicyModel),
        typeof(AzureActiveDirectoryModel),
        typeof(CertificateDescriptionModel),
        typeof(ClientCertificateCommonNameModel),
        typeof(ClientCertificateThumbprintModel),
        typeof(ClusterModel),
        typeof(ClusterHealthPolicyModel),
        typeof(ClusterListResultModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterPropertiesUpdateParametersModel),
        typeof(ClusterUpdateParametersModel),
        typeof(ClusterUpgradeDeltaHealthPolicyModel),
        typeof(ClusterUpgradePolicyModel),
        typeof(ClusterVersionDetailsModel),
        typeof(DiagnosticsStorageAccountConfigModel),
        typeof(EndpointRangeDescriptionModel),
        typeof(NodeTypeDescriptionModel),
        typeof(NotificationModel),
        typeof(NotificationTargetModel),
        typeof(ServerCertificateCommonNameModel),
        typeof(ServerCertificateCommonNamesModel),
        typeof(ServiceTypeDeltaHealthPolicyModel),
        typeof(ServiceTypeHealthPolicyModel),
        typeof(SettingsParameterDescriptionModel),
        typeof(SettingsSectionDescriptionModel),
        typeof(SystemDataModel),
    };
}
