using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ExecuteScriptActionsOperation(),
        new GetOperation(),
        new GetGatewaySettingsOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ResizeOperation(),
        new RotateDiskEncryptionKeyOperation(),
        new UpdateOperation(),
        new UpdateAutoScaleConfigurationOperation(),
        new UpdateGatewaySettingsOperation(),
        new UpdateIdentityCertificateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DaysOfWeekConstant),
        typeof(DirectoryTypeConstant),
        typeof(HDInsightClusterProvisioningStateConstant),
        typeof(JsonWebKeyEncryptionAlgorithmConstant),
        typeof(OSTypeConstant),
        typeof(PrivateLinkConstant),
        typeof(ResourceProviderConnectionConstant),
        typeof(TierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoscaleModel),
        typeof(AutoscaleCapacityModel),
        typeof(AutoscaleConfigurationUpdateParameterModel),
        typeof(AutoscaleRecurrenceModel),
        typeof(AutoscaleScheduleModel),
        typeof(AutoscaleTimeAndCapacityModel),
        typeof(ClientGroupInfoModel),
        typeof(ClusterModel),
        typeof(ClusterCreateParametersExtendedModel),
        typeof(ClusterCreatePropertiesModel),
        typeof(ClusterDefinitionModel),
        typeof(ClusterDiskEncryptionParametersModel),
        typeof(ClusterGetPropertiesModel),
        typeof(ClusterPatchParametersModel),
        typeof(ClusterResizeParametersModel),
        typeof(ComputeIsolationPropertiesModel),
        typeof(ComputeProfileModel),
        typeof(ConnectivityEndpointModel),
        typeof(DataDisksGroupsModel),
        typeof(DiskEncryptionPropertiesModel),
        typeof(EncryptionInTransitPropertiesModel),
        typeof(ErrorsModel),
        typeof(ExcludedServicesConfigModel),
        typeof(ExecuteScriptActionParametersModel),
        typeof(GatewaySettingsModel),
        typeof(HardwareProfileModel),
        typeof(KafkaRestPropertiesModel),
        typeof(LinuxOperatingSystemProfileModel),
        typeof(NetworkPropertiesModel),
        typeof(OsProfileModel),
        typeof(QuotaInfoModel),
        typeof(RoleModel),
        typeof(RuntimeScriptActionModel),
        typeof(ScriptActionModel),
        typeof(SecurityProfileModel),
        typeof(SshProfileModel),
        typeof(SshPublicKeyModel),
        typeof(StorageAccountModel),
        typeof(StorageProfileModel),
        typeof(UpdateClusterIdentityCertificateParametersModel),
        typeof(UpdateGatewaySettingsParametersModel),
        typeof(VirtualNetworkProfileModel),
    };
}
