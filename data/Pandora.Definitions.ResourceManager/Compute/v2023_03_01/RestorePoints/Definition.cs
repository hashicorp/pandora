using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.RestorePoints;

internal class Definition : ResourceDefinition
{
    public string Name => "RestorePoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RestorePointsCreateOperation(),
        new RestorePointsDeleteOperation(),
        new RestorePointsGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CachingTypesConstant),
        typeof(ComponentNamesConstant),
        typeof(ConsistencyModeTypesConstant),
        typeof(HyperVGenerationTypesConstant),
        typeof(LinuxPatchAssessmentModeConstant),
        typeof(LinuxVMGuestPatchAutomaticByPlatformRebootSettingConstant),
        typeof(LinuxVMGuestPatchModeConstant),
        typeof(OperatingSystemTypeConstant),
        typeof(PassNamesConstant),
        typeof(ProtocolTypesConstant),
        typeof(RestorePointEncryptionTypeConstant),
        typeof(RestorePointExpandOptionsConstant),
        typeof(SecurityEncryptionTypesConstant),
        typeof(SecurityTypesConstant),
        typeof(SettingNamesConstant),
        typeof(StatusLevelTypesConstant),
        typeof(StorageAccountTypesConstant),
        typeof(VirtualMachineSizeTypesConstant),
        typeof(WindowsPatchAssessmentModeConstant),
        typeof(WindowsVMGuestPatchAutomaticByPlatformRebootSettingConstant),
        typeof(WindowsVMGuestPatchModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalUnattendContentModel),
        typeof(ApiEntityReferenceModel),
        typeof(BootDiagnosticsModel),
        typeof(DiagnosticsProfileModel),
        typeof(DiskEncryptionSettingsModel),
        typeof(DiskRestorePointAttributesModel),
        typeof(DiskRestorePointInstanceViewModel),
        typeof(DiskRestorePointReplicationStatusModel),
        typeof(HardwareProfileModel),
        typeof(InstanceViewStatusModel),
        typeof(KeyVaultKeyReferenceModel),
        typeof(KeyVaultSecretReferenceModel),
        typeof(LinuxConfigurationModel),
        typeof(LinuxPatchSettingsModel),
        typeof(LinuxVMGuestPatchAutomaticByPlatformSettingsModel),
        typeof(ManagedDiskParametersModel),
        typeof(OSProfileModel),
        typeof(PatchSettingsModel),
        typeof(RestorePointModel),
        typeof(RestorePointEncryptionModel),
        typeof(RestorePointInstanceViewModel),
        typeof(RestorePointPropertiesModel),
        typeof(RestorePointSourceMetadataModel),
        typeof(RestorePointSourceVMDataDiskModel),
        typeof(RestorePointSourceVMOSDiskModel),
        typeof(RestorePointSourceVMStorageProfileModel),
        typeof(SecurityProfileModel),
        typeof(SshConfigurationModel),
        typeof(SshPublicKeyModel),
        typeof(SubResourceModel),
        typeof(UefiSettingsModel),
        typeof(VMDiskSecurityProfileModel),
        typeof(VMSizePropertiesModel),
        typeof(VaultCertificateModel),
        typeof(VaultSecretGroupModel),
        typeof(WinRMConfigurationModel),
        typeof(WinRMListenerModel),
        typeof(WindowsConfigurationModel),
        typeof(WindowsVMGuestPatchAutomaticByPlatformSettingsModel),
    };
}
