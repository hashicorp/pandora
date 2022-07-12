using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetVMs;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineScaleSetVMs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeallocateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetInstanceViewOperation(),
        new ListOperation(),
        new PerformMaintenanceOperation(),
        new PowerOffOperation(),
        new RedeployOperation(),
        new ReimageOperation(),
        new ReimageAllOperation(),
        new RestartOperation(),
        new RetrieveBootDiagnosticsDataOperation(),
        new RunCommandOperation(),
        new SimulateEvictionOperation(),
        new StartOperation(),
        new UpdateOperation(),
    };
}
