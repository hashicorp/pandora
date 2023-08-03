// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppleVpnConnectionTypeConstant
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

    [Description("CustomVpn")]
    @customVpn,

    [Description("CiscoIPSec")]
    @ciscoIPSec,

    [Description("Citrix")]
    @citrix,

    [Description("CiscoAnyConnectV2")]
    @ciscoAnyConnectV2,

    [Description("PaloAltoGlobalProtect")]
    @paloAltoGlobalProtect,

    [Description("ZscalerPrivateAccess")]
    @zscalerPrivateAccess,

    [Description("F5Access2018")]
    @f5Access2018,

    [Description("CitrixSso")]
    @citrixSso,

    [Description("PaloAltoGlobalProtectV2")]
    @paloAltoGlobalProtectV2,

    [Description("IkEv2")]
    @ikEv2,

    [Description("AlwaysOn")]
    @alwaysOn,

    [Description("MicrosoftTunnel")]
    @microsoftTunnel,

    [Description("NetMotionMobility")]
    @netMotionMobility,

    [Description("MicrosoftProtect")]
    @microsoftProtect,
}
