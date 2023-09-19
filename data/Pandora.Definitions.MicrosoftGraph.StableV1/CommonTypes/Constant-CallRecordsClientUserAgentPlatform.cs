// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallRecordsClientUserAgentPlatformConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Windows")]
    @windows,

    [Description("MacOS")]
    @macOS,

    [Description("IOS")]
    @iOS,

    [Description("Android")]
    @android,

    [Description("Web")]
    @web,

    [Description("IpPhone")]
    @ipPhone,

    [Description("RoomSystem")]
    @roomSystem,

    [Description("SurfaceHub")]
    @surfaceHub,

    [Description("HoloLens")]
    @holoLens,
}
