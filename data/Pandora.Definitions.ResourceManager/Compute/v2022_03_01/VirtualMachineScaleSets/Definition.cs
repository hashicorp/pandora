using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSets;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineScaleSets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConvertToSinglePlacementGroupOperation(),
        new CreateOrUpdateOperation(),
        new DeallocateOperation(),
        new DeleteOperation(),
        new DeleteInstancesOperation(),
        new ForceRecoveryServiceFabricPlatformUpdateDomainWalkOperation(),
        new GetOperation(),
        new GetInstanceViewOperation(),
        new GetOSUpgradeHistoryOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListByLocationOperation(),
        new ListSkusOperation(),
        new PerformMaintenanceOperation(),
        new PowerOffOperation(),
        new RedeployOperation(),
        new ReimageOperation(),
        new ReimageAllOperation(),
        new RestartOperation(),
        new SetOrchestrationServiceStateOperation(),
        new StartOperation(),
        new UpdateOperation(),
        new UpdateInstancesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CachingTypesConstant),
        typeof(ComponentNamesConstant),
        typeof(DeleteOptionsConstant),
        typeof(DiffDiskOptionsConstant),
        typeof(DiffDiskPlacementConstant),
        typeof(DiskCreateOptionTypesConstant),
        typeof(DiskDeleteOptionTypesConstant),
        typeof(ExpandTypesForGetVMScaleSetsConstant),
        typeof(IPVersionConstant),
        typeof(LinuxPatchAssessmentModeConstant),
        typeof(LinuxVMGuestPatchAutomaticByPlatformRebootSettingConstant),
        typeof(LinuxVMGuestPatchModeConstant),
        typeof(NetworkApiVersionConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(OrchestrationModeConstant),
        typeof(OrchestrationServiceNamesConstant),
        typeof(OrchestrationServiceStateConstant),
        typeof(OrchestrationServiceStateActionConstant),
        typeof(PassNamesConstant),
        typeof(ProtocolTypesConstant),
        typeof(PublicIPAddressSkuNameConstant),
        typeof(PublicIPAddressSkuTierConstant),
        typeof(RepairActionConstant),
        typeof(SecurityEncryptionTypesConstant),
        typeof(SecurityTypesConstant),
        typeof(SettingNamesConstant),
        typeof(StatusLevelTypesConstant),
        typeof(StorageAccountTypesConstant),
        typeof(UpgradeModeConstant),
        typeof(UpgradeOperationInvokerConstant),
        typeof(UpgradeStateConstant),
        typeof(VirtualMachineEvictionPolicyTypesConstant),
        typeof(VirtualMachinePriorityTypesConstant),
        typeof(VirtualMachineScaleSetScaleInRulesConstant),
        typeof(VirtualMachineScaleSetSkuScaleTypeConstant),
        typeof(WindowsPatchAssessmentModeConstant),
        typeof(WindowsVMGuestPatchAutomaticByPlatformRebootSettingConstant),
        typeof(WindowsVMGuestPatchModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalCapabilitiesModel),
        typeof(AdditionalUnattendContentModel),
        typeof(ApiEntityReferenceModel),
        typeof(ApiErrorModel),
        typeof(ApiErrorBaseModel),
        typeof(ApplicationProfileModel),
        typeof(AutomaticOSUpgradePolicyModel),
        typeof(AutomaticRepairsPolicyModel),
        typeof(BillingProfileModel),
        typeof(BootDiagnosticsModel),
        typeof(CapacityReservationProfileModel),
        typeof(DiagnosticsProfileModel),
        typeof(DiffDiskSettingsModel),
        typeof(ImageReferenceModel),
        typeof(InnerErrorModel),
        typeof(InstanceViewStatusModel),
        typeof(KeyVaultSecretReferenceModel),
        typeof(LinuxConfigurationModel),
        typeof(LinuxPatchSettingsModel),
        typeof(LinuxVMGuestPatchAutomaticByPlatformSettingsModel),
        typeof(OrchestrationServiceStateInputModel),
        typeof(OrchestrationServiceSummaryModel),
        typeof(PatchSettingsModel),
        typeof(PlanModel),
        typeof(PublicIPAddressSkuModel),
        typeof(RecoveryWalkResponseModel),
        typeof(RollbackStatusInfoModel),
        typeof(RollingUpgradePolicyModel),
        typeof(RollingUpgradeProgressInfoModel),
        typeof(ScaleInPolicyModel),
        typeof(ScheduledEventsProfileModel),
        typeof(SecurityProfileModel),
        typeof(SkuModel),
        typeof(SpotRestorePolicyModel),
        typeof(SshConfigurationModel),
        typeof(SshPublicKeyModel),
        typeof(SubResourceModel),
        typeof(TerminateNotificationProfileModel),
        typeof(UefiSettingsModel),
        typeof(UpgradeOperationHistoricalStatusInfoModel),
        typeof(UpgradeOperationHistoricalStatusInfoPropertiesModel),
        typeof(UpgradeOperationHistoryStatusModel),
        typeof(UpgradePolicyModel),
        typeof(VMDiskSecurityProfileModel),
        typeof(VMGalleryApplicationModel),
        typeof(VMScaleSetConvertToSinglePlacementGroupInputModel),
        typeof(VMSizePropertiesModel),
        typeof(VaultCertificateModel),
        typeof(VaultSecretGroupModel),
        typeof(VirtualHardDiskModel),
        typeof(VirtualMachineScaleSetModel),
        typeof(VirtualMachineScaleSetDataDiskModel),
        typeof(VirtualMachineScaleSetExtensionModel),
        typeof(VirtualMachineScaleSetExtensionProfileModel),
        typeof(VirtualMachineScaleSetExtensionPropertiesModel),
        typeof(VirtualMachineScaleSetHardwareProfileModel),
        typeof(VirtualMachineScaleSetIPConfigurationModel),
        typeof(VirtualMachineScaleSetIPConfigurationPropertiesModel),
        typeof(VirtualMachineScaleSetIPTagModel),
        typeof(VirtualMachineScaleSetInstanceViewModel),
        typeof(VirtualMachineScaleSetInstanceViewStatusesSummaryModel),
        typeof(VirtualMachineScaleSetManagedDiskParametersModel),
        typeof(VirtualMachineScaleSetNetworkConfigurationModel),
        typeof(VirtualMachineScaleSetNetworkConfigurationDnsSettingsModel),
        typeof(VirtualMachineScaleSetNetworkConfigurationPropertiesModel),
        typeof(VirtualMachineScaleSetNetworkProfileModel),
        typeof(VirtualMachineScaleSetOSDiskModel),
        typeof(VirtualMachineScaleSetOSProfileModel),
        typeof(VirtualMachineScaleSetPropertiesModel),
        typeof(VirtualMachineScaleSetPublicIPAddressConfigurationModel),
        typeof(VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettingsModel),
        typeof(VirtualMachineScaleSetPublicIPAddressConfigurationPropertiesModel),
        typeof(VirtualMachineScaleSetReimageParametersModel),
        typeof(VirtualMachineScaleSetSkuModel),
        typeof(VirtualMachineScaleSetSkuCapacityModel),
        typeof(VirtualMachineScaleSetStorageProfileModel),
        typeof(VirtualMachineScaleSetUpdateModel),
        typeof(VirtualMachineScaleSetUpdateIPConfigurationModel),
        typeof(VirtualMachineScaleSetUpdateIPConfigurationPropertiesModel),
        typeof(VirtualMachineScaleSetUpdateNetworkConfigurationModel),
        typeof(VirtualMachineScaleSetUpdateNetworkConfigurationPropertiesModel),
        typeof(VirtualMachineScaleSetUpdateNetworkProfileModel),
        typeof(VirtualMachineScaleSetUpdateOSDiskModel),
        typeof(VirtualMachineScaleSetUpdateOSProfileModel),
        typeof(VirtualMachineScaleSetUpdatePropertiesModel),
        typeof(VirtualMachineScaleSetUpdatePublicIPAddressConfigurationModel),
        typeof(VirtualMachineScaleSetUpdatePublicIPAddressConfigurationPropertiesModel),
        typeof(VirtualMachineScaleSetUpdateStorageProfileModel),
        typeof(VirtualMachineScaleSetUpdateVMProfileModel),
        typeof(VirtualMachineScaleSetVMExtensionsSummaryModel),
        typeof(VirtualMachineScaleSetVMInstanceIDsModel),
        typeof(VirtualMachineScaleSetVMInstanceRequiredIDsModel),
        typeof(VirtualMachineScaleSetVMProfileModel),
        typeof(VirtualMachineStatusCodeCountModel),
        typeof(WinRMConfigurationModel),
        typeof(WinRMListenerModel),
        typeof(WindowsConfigurationModel),
        typeof(WindowsVMGuestPatchAutomaticByPlatformSettingsModel),
    };
}
