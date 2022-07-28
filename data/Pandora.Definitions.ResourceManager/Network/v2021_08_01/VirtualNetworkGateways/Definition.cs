using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGateways;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkGateways";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DisconnectVirtualNetworkGatewayVpnConnectionsOperation(),
        new GenerateVpnProfileOperation(),
        new GeneratevpnclientpackageOperation(),
        new GetOperation(),
        new GetAdvertisedRoutesOperation(),
        new GetBgpPeerStatusOperation(),
        new GetLearnedRoutesOperation(),
        new GetVpnProfilePackageUrlOperation(),
        new GetVpnclientConnectionHealthOperation(),
        new GetVpnclientIPsecParametersOperation(),
        new ListOperation(),
        new ListConnectionsOperation(),
        new ResetOperation(),
        new ResetVpnClientSharedKeyOperation(),
        new SetVpnclientIPsecParametersOperation(),
        new StartPacketCaptureOperation(),
        new StopPacketCaptureOperation(),
        new SupportedVpnDevicesOperation(),
        new UpdateTagsOperation(),
        new VpnDeviceConfigurationScriptOperation(),
    };
}
