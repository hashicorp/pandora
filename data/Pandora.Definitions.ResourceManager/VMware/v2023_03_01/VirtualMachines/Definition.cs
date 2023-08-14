using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.VirtualMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new RestrictMovementOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(VirtualMachineRestrictMovementStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(VirtualMachineModel),
        typeof(VirtualMachinePropertiesModel),
        typeof(VirtualMachineRestrictMovementModel),
    };
}
