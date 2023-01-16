using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddDataDiskOperation(),
        new ApplyArtifactsOperation(),
        new ClaimOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DetachDataDiskOperation(),
        new GetOperation(),
        new GetRdpFileContentsOperation(),
        new ListOperation(),
        new ListApplicableSchedulesOperation(),
        new RedeployOperation(),
        new ResizeOperation(),
        new RestartOperation(),
        new StartOperation(),
        new StopOperation(),
        new TransferDisksOperation(),
        new UnClaimOperation(),
        new UpdateOperation(),
    };
}
