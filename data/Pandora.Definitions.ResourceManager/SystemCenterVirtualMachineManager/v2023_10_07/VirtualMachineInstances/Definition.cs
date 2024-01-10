using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateCheckpointOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DeleteCheckpointOperation(),
        new GetOperation(),
        new ListOperation(),
        new RestartOperation(),
        new RestoreCheckpointOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllocationMethodConstant),
        typeof(CreateDiffDiskConstant),
        typeof(DeleteFromHostConstant),
        typeof(DynamicMemoryEnabledConstant),
        typeof(ForceConstant),
        typeof(IsHighlyAvailableConstant),
        typeof(LimitCPUForMigrationConstant),
        typeof(OsTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(SkipShutdownConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailabilitySetListAvailabilitySetsInlinedModel),
        typeof(CheckpointModel),
        typeof(ExtendedLocationModel),
        typeof(HardwareProfileModel),
        typeof(HardwareProfileUpdateModel),
        typeof(InfrastructureProfileModel),
        typeof(InfrastructureProfileUpdateModel),
        typeof(NetworkInterfaceModel),
        typeof(NetworkInterfaceUpdateModel),
        typeof(NetworkProfileModel),
        typeof(NetworkProfileUpdateModel),
        typeof(OsProfileForVMInstanceModel),
        typeof(StopVirtualMachineOptionsModel),
        typeof(StorageProfileModel),
        typeof(StorageProfileUpdateModel),
        typeof(StorageQoSPolicyDetailsModel),
        typeof(VirtualDiskModel),
        typeof(VirtualDiskUpdateModel),
        typeof(VirtualMachineCreateCheckpointModel),
        typeof(VirtualMachineDeleteCheckpointModel),
        typeof(VirtualMachineInstanceModel),
        typeof(VirtualMachineInstancePropertiesModel),
        typeof(VirtualMachineInstanceUpdateModel),
        typeof(VirtualMachineInstanceUpdatePropertiesModel),
        typeof(VirtualMachineRestoreCheckpointModel),
    };
}
