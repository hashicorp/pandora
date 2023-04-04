using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssessPatchesOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new InstallPatchesOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RestartOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiskModeConstant),
        typeof(DiskTypeConstant),
        typeof(FirmwareTypeConstant),
        typeof(IPAddressAllocationMethodConstant),
        typeof(NICTypeConstant),
        typeof(OsTypeConstant),
        typeof(OsTypeUMConstant),
        typeof(PatchOperationStartedByConstant),
        typeof(PatchOperationStatusConstant),
        typeof(PatchServiceUsedConstant),
        typeof(PowerOnBootOptionConstant),
        typeof(SCSIControllerTypeConstant),
        typeof(StatusTypesConstant),
        typeof(VMGuestPatchClassificationLinuxConstant),
        typeof(VMGuestPatchClassificationWindowsConstant),
        typeof(VMGuestPatchRebootSettingConstant),
        typeof(VMGuestPatchRebootStatusConstant),
        typeof(VirtualSCSISharingConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailablePatchCountByClassificationModel),
        typeof(ErrorDetailModel),
        typeof(ExtendedLocationModel),
        typeof(GuestAgentProfileModel),
        typeof(HardwareProfileModel),
        typeof(LinuxParametersModel),
        typeof(NetworkInterfaceModel),
        typeof(NetworkInterfaceUpdateModel),
        typeof(NetworkProfileModel),
        typeof(NetworkProfileUpdateModel),
        typeof(NicIPAddressSettingsModel),
        typeof(NicIPSettingsModel),
        typeof(OsProfileModel),
        typeof(OsProfileLinuxConfigurationModel),
        typeof(OsProfileUpdateModel),
        typeof(OsProfileUpdateLinuxConfigurationModel),
        typeof(OsProfileUpdateWindowsConfigurationModel),
        typeof(OsProfileWindowsConfigurationModel),
        typeof(PatchSettingsModel),
        typeof(PlacementProfileModel),
        typeof(ResourceStatusModel),
        typeof(SecurityProfileModel),
        typeof(StopVirtualMachineOptionsModel),
        typeof(StorageProfileModel),
        typeof(StorageProfileUpdateModel),
        typeof(UefiSettingsModel),
        typeof(VirtualDiskModel),
        typeof(VirtualDiskUpdateModel),
        typeof(VirtualMachineModel),
        typeof(VirtualMachineAssessPatchesResultModel),
        typeof(VirtualMachineInstallPatchesParametersModel),
        typeof(VirtualMachineInstallPatchesResultModel),
        typeof(VirtualMachinePropertiesModel),
        typeof(VirtualMachineUpdateModel),
        typeof(VirtualMachineUpdatePropertiesModel),
        typeof(VirtualSCSIControllerModel),
        typeof(WindowsParametersModel),
    };
}
