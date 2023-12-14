using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineTemplates;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineTemplates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllocationMethodConstant),
        typeof(CreateDiffDiskConstant),
        typeof(DynamicMemoryEnabledConstant),
        typeof(ForceConstant),
        typeof(IsCustomizableConstant),
        typeof(IsHighlyAvailableConstant),
        typeof(LimitCPUForMigrationConstant),
        typeof(OsTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExtendedLocationModel),
        typeof(NetworkInterfaceModel),
        typeof(ResourcePatchModel),
        typeof(StorageQoSPolicyDetailsModel),
        typeof(VirtualDiskModel),
        typeof(VirtualMachineTemplateModel),
        typeof(VirtualMachineTemplatePropertiesModel),
    };
}
