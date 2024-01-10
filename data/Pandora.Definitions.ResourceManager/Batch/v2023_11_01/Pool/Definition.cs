using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.Pool;

internal class Definition : ResourceDefinition
{
    public string Name => "Pool";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new DisableAutoScaleOperation(),
        new GetOperation(),
        new ListByBatchAccountOperation(),
        new StopResizeOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllocationStateConstant),
        typeof(AutoUserScopeConstant),
        typeof(CachingTypeConstant),
        typeof(CertificateStoreLocationConstant),
        typeof(CertificateVisibilityConstant),
        typeof(ComputeNodeDeallocationOptionConstant),
        typeof(ComputeNodeFillTypeConstant),
        typeof(ContainerTypeConstant),
        typeof(ContainerWorkingDirectoryConstant),
        typeof(DiffDiskPlacementConstant),
        typeof(DiskEncryptionTargetConstant),
        typeof(DynamicVNetAssignmentScopeConstant),
        typeof(ElevationLevelConstant),
        typeof(IPAddressProvisioningTypeConstant),
        typeof(InboundEndpointProtocolConstant),
        typeof(InterNodeCommunicationStateConstant),
        typeof(LoginModeConstant),
        typeof(NetworkSecurityGroupRuleAccessConstant),
        typeof(NodeCommunicationModeConstant),
        typeof(NodePlacementPolicyTypeConstant),
        typeof(PoolProvisioningStateConstant),
        typeof(SecurityTypesConstant),
        typeof(StorageAccountTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationPackageReferenceModel),
        typeof(AutoScaleRunModel),
        typeof(AutoScaleRunErrorModel),
        typeof(AutoScaleSettingsModel),
        typeof(AutoUserSpecificationModel),
        typeof(AzureBlobFileSystemConfigurationModel),
        typeof(AzureFileShareConfigurationModel),
        typeof(CIFSMountConfigurationModel),
        typeof(CertificateReferenceModel),
        typeof(CloudServiceConfigurationModel),
        typeof(ComputeNodeIdentityReferenceModel),
        typeof(ContainerConfigurationModel),
        typeof(ContainerRegistryModel),
        typeof(DataDiskModel),
        typeof(DeploymentConfigurationModel),
        typeof(DiffDiskSettingsModel),
        typeof(DiskEncryptionConfigurationModel),
        typeof(EnvironmentSettingModel),
        typeof(FixedScaleSettingsModel),
        typeof(ImageReferenceModel),
        typeof(InboundNatPoolModel),
        typeof(LinuxUserConfigurationModel),
        typeof(ManagedDiskModel),
        typeof(MetadataItemModel),
        typeof(MountConfigurationModel),
        typeof(NFSMountConfigurationModel),
        typeof(NetworkConfigurationModel),
        typeof(NetworkSecurityGroupRuleModel),
        typeof(NodePlacementConfigurationModel),
        typeof(OSDiskModel),
        typeof(PoolModel),
        typeof(PoolEndpointConfigurationModel),
        typeof(PoolPropertiesModel),
        typeof(PublicIPAddressConfigurationModel),
        typeof(ResizeErrorModel),
        typeof(ResizeOperationStatusModel),
        typeof(ResourceFileModel),
        typeof(ScaleSettingsModel),
        typeof(SecurityProfileModel),
        typeof(ServiceArtifactReferenceModel),
        typeof(StartTaskModel),
        typeof(TaskContainerSettingsModel),
        typeof(TaskSchedulingPolicyModel),
        typeof(UefiSettingsModel),
        typeof(UserAccountModel),
        typeof(UserIdentityModel),
        typeof(VirtualMachineConfigurationModel),
        typeof(VmExtensionModel),
        typeof(WindowsConfigurationModel),
        typeof(WindowsUserConfigurationModel),
    };
}
