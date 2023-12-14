// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessRemoteNetworkHealthEventStatusConstant
{
    [Description("TunnelDisconnected")]
    @tunnelDisconnected,

    [Description("TunnelConnected")]
    @tunnelConnected,

    [Description("BgpDisconnected")]
    @bgpDisconnected,

    [Description("BgpConnected")]
    @bgpConnected,

    [Description("RemoteNetworkAlive")]
    @remoteNetworkAlive,
}
