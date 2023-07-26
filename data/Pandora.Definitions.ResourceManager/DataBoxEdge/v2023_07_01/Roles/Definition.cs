using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Roles;

internal class Definition : ResourceDefinition
{
    public string Name => "Roles";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDataBoxEdgeDeviceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EncryptionAlgorithmConstant),
        typeof(HostPlatformTypeConstant),
        typeof(KubernetesNodeTypeConstant),
        typeof(KubernetesStateConstant),
        typeof(MountTypeConstant),
        typeof(PlatformTypeConstant),
        typeof(PosixComplianceStatusConstant),
        typeof(RoleStatusConstant),
        typeof(RoleTypesConstant),
        typeof(SubscriptionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsymmetricEncryptedSecretModel),
        typeof(AuthenticationModel),
        typeof(CloudEdgeManagementRoleModel),
        typeof(CloudEdgeManagementRolePropertiesModel),
        typeof(CniConfigModel),
        typeof(ComputeResourceModel),
        typeof(EdgeProfileModel),
        typeof(EdgeProfileSubscriptionModel),
        typeof(EtcdInfoModel),
        typeof(ImageRepositoryCredentialModel),
        typeof(IoTDeviceInfoModel),
        typeof(IoTEdgeAgentInfoModel),
        typeof(IoTRoleModel),
        typeof(IoTRolePropertiesModel),
        typeof(KubernetesClusterInfoModel),
        typeof(KubernetesIPConfigurationModel),
        typeof(KubernetesRoleModel),
        typeof(KubernetesRoleComputeModel),
        typeof(KubernetesRoleNetworkModel),
        typeof(KubernetesRolePropertiesModel),
        typeof(KubernetesRoleResourcesModel),
        typeof(KubernetesRoleStorageModel),
        typeof(KubernetesRoleStorageClassInfoModel),
        typeof(LoadBalancerConfigModel),
        typeof(MECRoleModel),
        typeof(MECRolePropertiesModel),
        typeof(MountPointMapModel),
        typeof(NodeInfoModel),
        typeof(RoleModel),
        typeof(SubscriptionPropertiesModel),
        typeof(SubscriptionRegisteredFeaturesModel),
        typeof(SymmetricKeyModel),
    };
}
