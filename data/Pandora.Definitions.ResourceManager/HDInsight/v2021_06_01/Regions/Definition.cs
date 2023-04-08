using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;

internal class Definition : ResourceDefinition
{
    public string Name => "Regions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LocationsCheckNameAvailabilityOperation(),
        new LocationsGetCapabilitiesOperation(),
        new LocationsListBillingSpecsOperation(),
        new LocationsListUsagesOperation(),
        new LocationsValidateClusterCreateRequestOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DaysOfWeekConstant),
        typeof(DirectoryTypeConstant),
        typeof(FilterModeConstant),
        typeof(JsonWebKeyEncryptionAlgorithmConstant),
        typeof(OSTypeConstant),
        typeof(PrivateIPAllocationMethodConstant),
        typeof(PrivateLinkConstant),
        typeof(PrivateLinkConfigurationProvisioningStateConstant),
        typeof(ResourceProviderConnectionConstant),
        typeof(TierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AaddsResourceDetailsModel),
        typeof(AutoscaleModel),
        typeof(AutoscaleCapacityModel),
        typeof(AutoscaleRecurrenceModel),
        typeof(AutoscaleScheduleModel),
        typeof(AutoscaleTimeAndCapacityModel),
        typeof(BillingMetersModel),
        typeof(BillingResourcesModel),
        typeof(BillingResponseListResultModel),
        typeof(CapabilitiesResultModel),
        typeof(ClientGroupInfoModel),
        typeof(ClusterCreatePropertiesModel),
        typeof(ClusterCreateRequestValidationParametersModel),
        typeof(ClusterCreateValidationResultModel),
        typeof(ClusterDefinitionModel),
        typeof(ComputeIsolationPropertiesModel),
        typeof(ComputeProfileModel),
        typeof(DataDisksGroupsModel),
        typeof(DiskBillingMetersModel),
        typeof(DiskEncryptionPropertiesModel),
        typeof(EncryptionInTransitPropertiesModel),
        typeof(HardwareProfileModel),
        typeof(IPConfigurationModel),
        typeof(IPConfigurationPropertiesModel),
        typeof(KafkaRestPropertiesModel),
        typeof(LinuxOperatingSystemProfileModel),
        typeof(LocalizedNameModel),
        typeof(NameAvailabilityCheckRequestParametersModel),
        typeof(NameAvailabilityCheckResultModel),
        typeof(NetworkPropertiesModel),
        typeof(OsProfileModel),
        typeof(PrivateLinkConfigurationModel),
        typeof(PrivateLinkConfigurationPropertiesModel),
        typeof(QuotaCapabilityModel),
        typeof(RegionalQuotaCapabilityModel),
        typeof(RegionsCapabilityModel),
        typeof(ResourceIdModel),
        typeof(RoleModel),
        typeof(ScriptActionModel),
        typeof(SecurityProfileModel),
        typeof(SshProfileModel),
        typeof(SshPublicKeyModel),
        typeof(StorageAccountModel),
        typeof(StorageProfileModel),
        typeof(UsageModel),
        typeof(UsagesListResultModel),
        typeof(VMSizeCompatibilityFilterV2Model),
        typeof(VMSizePropertyModel),
        typeof(ValidationErrorInfoModel),
        typeof(VersionSpecModel),
        typeof(VersionsCapabilityModel),
        typeof(VirtualNetworkProfileModel),
    };
}
