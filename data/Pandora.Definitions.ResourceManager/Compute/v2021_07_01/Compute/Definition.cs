using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.Compute;

internal class Definition : ResourceDefinition
{
    public string Name => "Compute";
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
        typeof(LinuxPatchAssessmentModeConstant),
        typeof(LinuxVMGuestPatchModeConstant),
        typeof(OperatingSystemTypeConstant),
        typeof(PassNamesConstant),
        typeof(ProtocolTypesConstant),
        typeof(SecurityTypesConstant),
        typeof(SettingNamesConstant),
        typeof(StorageAccountTypesConstant),
        typeof(VirtualMachineSizeTypesConstant),
        typeof(WindowsPatchAssessmentModeConstant),
        typeof(WindowsVMGuestPatchModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalUnattendContentModel),
        typeof(ApiEntityReferenceModel),
        typeof(BootDiagnosticsModel),
        typeof(DiagnosticsProfileModel),
        typeof(DiskEncryptionSettingsModel),
        typeof(HardwareProfileModel),
        typeof(KeyVaultKeyReferenceModel),
        typeof(KeyVaultSecretReferenceModel),
        typeof(LinuxConfigurationModel),
        typeof(LinuxPatchSettingsModel),
        typeof(ManagedDiskParametersModel),
        typeof(OSProfileModel),
        typeof(PatchSettingsModel),
        typeof(RestorePointModel),
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
        typeof(VMSizePropertiesModel),
        typeof(VaultCertificateModel),
        typeof(VaultSecretGroupModel),
        typeof(WinRMConfigurationModel),
        typeof(WinRMListenerModel),
        typeof(WindowsConfigurationModel),
    };
}
