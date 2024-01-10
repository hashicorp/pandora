using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineTemplates;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineTemplates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
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
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExtendedLocationModel),
        typeof(NetworkInterfaceModel),
        typeof(NicIPAddressSettingsModel),
        typeof(NicIPSettingsModel),
        typeof(ResourcePatchModel),
        typeof(ResourceStatusModel),
        typeof(VirtualDiskModel),
        typeof(VirtualMachineTemplateModel),
        typeof(VirtualMachineTemplatePropertiesModel),
    };
}
