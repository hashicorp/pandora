using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
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
        typeof(PowerOnBootOptionConstant),
        typeof(ProvisioningStateConstant),
        typeof(SCSIControllerTypeConstant),
        typeof(VirtualSCSISharingConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExtendedLocationModel),
        typeof(HardwareProfileModel),
        typeof(InfrastructureProfileModel),
        typeof(NetworkInterfaceModel),
        typeof(NetworkInterfaceUpdateModel),
        typeof(NetworkProfileModel),
        typeof(NetworkProfileUpdateModel),
        typeof(NicIPAddressSettingsModel),
        typeof(NicIPSettingsModel),
        typeof(OsProfileForVMInstanceModel),
        typeof(PlacementProfileModel),
        typeof(ResourceStatusModel),
        typeof(SecurityProfileModel),
        typeof(StopVirtualMachineOptionsModel),
        typeof(StorageProfileModel),
        typeof(StorageProfileUpdateModel),
        typeof(UefiSettingsModel),
        typeof(VirtualDiskModel),
        typeof(VirtualDiskUpdateModel),
        typeof(VirtualMachineInstanceModel),
        typeof(VirtualMachineInstancePropertiesModel),
        typeof(VirtualMachineInstanceUpdateModel),
        typeof(VirtualMachineInstanceUpdatePropertiesModel),
        typeof(VirtualSCSIControllerModel),
    };
}
