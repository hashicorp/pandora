using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2022_09_01.ContainerInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerInstance";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContainerGroupsCreateOrUpdateOperation(),
        new ContainerGroupsDeleteOperation(),
        new ContainerGroupsGetOperation(),
        new ContainerGroupsGetOutboundNetworkDependenciesEndpointsOperation(),
        new ContainerGroupsListOperation(),
        new ContainerGroupsListByResourceGroupOperation(),
        new ContainerGroupsRestartOperation(),
        new ContainerGroupsStartOperation(),
        new ContainerGroupsStopOperation(),
        new ContainerGroupsUpdateOperation(),
        new ContainersAttachOperation(),
        new ContainersExecuteCommandOperation(),
        new ContainersListLogsOperation(),
        new LocationListCachedImagesOperation(),
        new LocationListCapabilitiesOperation(),
        new LocationListUsageOperation(),
        new SubnetServiceAssociationLinkDeleteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ContainerGroupIPAddressTypeConstant),
        typeof(ContainerGroupNetworkProtocolConstant),
        typeof(ContainerGroupRestartPolicyConstant),
        typeof(ContainerGroupSkuConstant),
        typeof(ContainerNetworkProtocolConstant),
        typeof(DnsNameLabelReusePolicyConstant),
        typeof(GpuSkuConstant),
        typeof(LogAnalyticsLogTypeConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(SchemeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFileVolumeModel),
        typeof(CachedImagesModel),
        typeof(CapabilitiesModel),
        typeof(CapabilitiesCapabilitiesModel),
        typeof(ContainerModel),
        typeof(ContainerAttachResponseModel),
        typeof(ContainerExecModel),
        typeof(ContainerExecRequestModel),
        typeof(ContainerExecRequestTerminalSizeModel),
        typeof(ContainerExecResponseModel),
        typeof(ContainerGroupModel),
        typeof(ContainerGroupDiagnosticsModel),
        typeof(ContainerGroupPropertiesPropertiesModel),
        typeof(ContainerGroupPropertiesPropertiesInstanceViewModel),
        typeof(ContainerGroupSubnetIdModel),
        typeof(ContainerHTTPGetModel),
        typeof(ContainerPortModel),
        typeof(ContainerProbeModel),
        typeof(ContainerPropertiesModel),
        typeof(ContainerPropertiesInstanceViewModel),
        typeof(ContainerStateModel),
        typeof(DeploymentExtensionSpecModel),
        typeof(DeploymentExtensionSpecPropertiesModel),
        typeof(DnsConfigurationModel),
        typeof(EncryptionPropertiesModel),
        typeof(EnvironmentVariableModel),
        typeof(EventModel),
        typeof(GitRepoVolumeModel),
        typeof(GpuResourceModel),
        typeof(HTTPHeaderModel),
        typeof(IPAddressModel),
        typeof(ImageRegistryCredentialModel),
        typeof(InitContainerDefinitionModel),
        typeof(InitContainerPropertiesDefinitionModel),
        typeof(InitContainerPropertiesDefinitionInstanceViewModel),
        typeof(LogAnalyticsModel),
        typeof(LogsModel),
        typeof(PortModel),
        typeof(ResourceModel),
        typeof(ResourceLimitsModel),
        typeof(ResourceRequestsModel),
        typeof(ResourceRequirementsModel),
        typeof(UsageModel),
        typeof(UsageListResultModel),
        typeof(UsageNameModel),
        typeof(VolumeModel),
        typeof(VolumeMountModel),
    };
}
