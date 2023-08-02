using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.VirtualMachine;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachine";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new LabPlansSaveImageOperation(),
        new ListByLabOperation(),
        new RedeployOperation(),
        new ReimageOperation(),
        new ResetPasswordOperation(),
        new StartOperation(),
        new StopOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(VirtualMachineStateConstant),
        typeof(VirtualMachineTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ResetPasswordBodyModel),
        typeof(ResourceOperationErrorModel),
        typeof(SaveImageBodyModel),
        typeof(VirtualMachineModel),
        typeof(VirtualMachineConnectionProfileModel),
        typeof(VirtualMachinePropertiesModel),
    };
}
