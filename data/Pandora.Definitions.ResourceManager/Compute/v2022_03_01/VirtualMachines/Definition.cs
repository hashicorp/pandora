using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssessPatchesOperation(),
        new CaptureOperation(),
        new ConvertToManagedDisksOperation(),
        new CreateOrUpdateOperation(),
        new DeallocateOperation(),
        new DeleteOperation(),
        new GeneralizeOperation(),
        new GetOperation(),
        new InstallPatchesOperation(),
        new InstanceViewOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAvailableSizesOperation(),
        new ListByLocationOperation(),
        new PerformMaintenanceOperation(),
        new PowerOffOperation(),
        new ReapplyOperation(),
        new RedeployOperation(),
        new ReimageOperation(),
        new RestartOperation(),
        new RetrieveBootDiagnosticsDataOperation(),
        new RunCommandOperation(),
        new SimulateEvictionOperation(),
        new StartOperation(),
        new UpdateOperation(),
    };
}
