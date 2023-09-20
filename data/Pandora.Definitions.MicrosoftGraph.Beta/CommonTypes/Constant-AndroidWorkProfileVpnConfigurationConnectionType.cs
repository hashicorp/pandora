// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidWorkProfileVpnConfigurationConnectionTypeConstant
{
    [Description("CiscoAnyConnect")]
    @ciscoAnyConnect,

    [Description("PulseSecure")]
    @pulseSecure,

    [Description("F5EdgeClient")]
    @f5EdgeClient,

    [Description("DellSonicWallMobileConnect")]
    @dellSonicWallMobileConnect,

    [Description("CheckPointCapsuleVpn")]
    @checkPointCapsuleVpn,

    [Description("Citrix")]
    @citrix,

    [Description("PaloAltoGlobalProtect")]
    @paloAltoGlobalProtect,

    [Description("MicrosoftTunnel")]
    @microsoftTunnel,

    [Description("NetMotionMobility")]
    @netMotionMobility,

    [Description("MicrosoftProtect")]
    @microsoftProtect,
}
