// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10VpnConnectionTypeConstant
{
    [Description("PulseSecure")]
    @pulseSecure,

    [Description("F5EdgeClient")]
    @f5EdgeClient,

    [Description("DellSonicWallMobileConnect")]
    @dellSonicWallMobileConnect,

    [Description("CheckPointCapsuleVpn")]
    @checkPointCapsuleVpn,

    [Description("Automatic")]
    @automatic,

    [Description("IkEv2")]
    @ikEv2,

    [Description("L2tp")]
    @l2tp,

    [Description("Pptp")]
    @pptp,

    [Description("Citrix")]
    @citrix,

    [Description("PaloAltoGlobalProtect")]
    @paloAltoGlobalProtect,

    [Description("CiscoAnyConnect")]
    @ciscoAnyConnect,

    [Description("MicrosoftTunnel")]
    @microsoftTunnel,
}
