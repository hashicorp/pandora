using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGatewayConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkGatewayConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetIkeSasOperation(),
        new GetSharedKeyOperation(),
        new ListOperation(),
        new ResetConnectionOperation(),
        new ResetSharedKeyOperation(),
        new SetSharedKeyOperation(),
        new StartPacketCaptureOperation(),
        new StopPacketCaptureOperation(),
        new UpdateTagsOperation(),
    };
}
