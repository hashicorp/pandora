using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineScaleSets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConvertToSinglePlacementGroupOperation(),
        new CreateOrUpdateOperation(),
        new DeallocateOperation(),
        new DeleteOperation(),
        new DeleteInstancesOperation(),
        new ForceRecoveryServiceFabricPlatformUpdateDomainWalkOperation(),
        new GetOperation(),
        new GetInstanceViewOperation(),
        new GetOSUpgradeHistoryOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListByLocationOperation(),
        new ListSkusOperation(),
        new PerformMaintenanceOperation(),
        new PowerOffOperation(),
        new RedeployOperation(),
        new ReimageOperation(),
        new ReimageAllOperation(),
        new RestartOperation(),
        new SetOrchestrationServiceStateOperation(),
        new StartOperation(),
        new UpdateOperation(),
        new UpdateInstancesOperation(),
    };
}
