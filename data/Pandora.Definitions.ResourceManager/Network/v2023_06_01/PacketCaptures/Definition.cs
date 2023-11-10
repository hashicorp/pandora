using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.PacketCaptures;

internal class Definition : ResourceDefinition
{
    public string Name => "PacketCaptures";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetStatusOperation(),
        new ListOperation(),
        new StopOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PacketCaptureTargetTypeConstant),
        typeof(PcErrorConstant),
        typeof(PcProtocolConstant),
        typeof(PcStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PacketCaptureModel),
        typeof(PacketCaptureFilterModel),
        typeof(PacketCaptureListResultModel),
        typeof(PacketCaptureMachineScopeModel),
        typeof(PacketCaptureParametersModel),
        typeof(PacketCaptureQueryStatusResultModel),
        typeof(PacketCaptureResultModel),
        typeof(PacketCaptureResultPropertiesModel),
        typeof(PacketCaptureStorageLocationModel),
    };
}
