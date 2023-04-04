using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "SAPVirtualInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConfigurationTypeConstant),
        typeof(DiskSkuNameConstant),
        typeof(NamingPatternTypeConstant),
        typeof(OSTypeConstant),
        typeof(SAPConfigurationTypeConstant),
        typeof(SAPDatabaseTypeConstant),
        typeof(SAPDeploymentTypeConstant),
        typeof(SAPEnvironmentTypeConstant),
        typeof(SAPHealthStateConstant),
        typeof(SAPHighAvailabilityTypeConstant),
        typeof(SAPProductTypeConstant),
        typeof(SAPSoftwareInstallationTypeConstant),
        typeof(SAPVirtualInstanceStateConstant),
        typeof(SAPVirtualInstanceStatusConstant),
        typeof(SapVirtualInstanceProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationServerConfigurationModel),
        typeof(ApplicationServerFullResourceNamesModel),
        typeof(CentralServerConfigurationModel),
        typeof(CentralServerFullResourceNamesModel),
        typeof(CreateAndMountFileShareConfigurationModel),
        typeof(DatabaseConfigurationModel),
        typeof(DatabaseServerFullResourceNamesModel),
        typeof(DeployerVMPackagesModel),
        typeof(DeploymentConfigurationModel),
        typeof(DeploymentWithOSConfigurationModel),
        typeof(DiscoveryConfigurationModel),
        typeof(DiskConfigurationModel),
        typeof(DiskSkuModel),
        typeof(DiskVolumeConfigurationModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDefinitionModel),
        typeof(ErrorDetailModel),
        typeof(ExternalInstallationSoftwareConfigurationModel),
        typeof(FileShareConfigurationModel),
        typeof(HighAvailabilityConfigurationModel),
        typeof(HighAvailabilitySoftwareConfigurationModel),
        typeof(ImageReferenceModel),
        typeof(InfrastructureConfigurationModel),
        typeof(LinuxConfigurationModel),
        typeof(LoadBalancerResourceNamesModel),
        typeof(ManagedRGConfigurationModel),
        typeof(MountFileShareConfigurationModel),
        typeof(NetworkConfigurationModel),
        typeof(NetworkInterfaceResourceNamesModel),
        typeof(OSConfigurationModel),
        typeof(OSProfileModel),
        typeof(OperationStatusResultModel),
        typeof(OsSapConfigurationModel),
        typeof(SAPConfigurationModel),
        typeof(SAPInstallWithoutOSConfigSoftwareConfigurationModel),
        typeof(SAPVirtualInstanceModel),
        typeof(SAPVirtualInstanceErrorModel),
        typeof(SAPVirtualInstancePropertiesModel),
        typeof(ServiceInitiatedSoftwareConfigurationModel),
        typeof(SharedStorageResourceNamesModel),
        typeof(SingleServerConfigurationModel),
        typeof(SingleServerCustomResourceNamesModel),
        typeof(SingleServerFullResourceNamesModel),
        typeof(SkipFileShareConfigurationModel),
        typeof(SoftwareConfigurationModel),
        typeof(SshConfigurationModel),
        typeof(SshKeyPairModel),
        typeof(SshPublicKeyModel),
        typeof(StopRequestModel),
        typeof(StorageConfigurationModel),
        typeof(ThreeTierConfigurationModel),
        typeof(ThreeTierCustomResourceNamesModel),
        typeof(ThreeTierFullResourceNamesModel),
        typeof(UpdateSAPVirtualInstanceRequestModel),
        typeof(VirtualMachineConfigurationModel),
        typeof(VirtualMachineResourceNamesModel),
        typeof(WindowsConfigurationModel),
    };
}
