// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamworkDeviceTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("IpPhone")]
    @ipPhone,

    [Description("TeamsRoom")]
    @teamsRoom,

    [Description("SurfaceHub")]
    @surfaceHub,

    [Description("CollaborationBar")]
    @collaborationBar,

    [Description("TeamsDisplay")]
    @teamsDisplay,

    [Description("TouchConsole")]
    @touchConsole,

    [Description("LowCostPhone")]
    @lowCostPhone,

    [Description("TeamsPanel")]
    @teamsPanel,

    [Description("Sip")]
    @sip,
}
