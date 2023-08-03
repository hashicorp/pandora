// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AudioCodecConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Invalid")]
    @invalid,

    [Description("Cn")]
    @cn,

    [Description("Pcma")]
    @pcma,

    [Description("Pcmu")]
    @pcmu,

    [Description("AmrWide")]
    @amrWide,

    [Description("G722")]
    @g722,

    [Description("G7221")]
    @g7221,

    [Description("G7221c")]
    @g7221c,

    [Description("G729")]
    @g729,

    [Description("MultiChannelAudio")]
    @multiChannelAudio,

    [Description("Muchv2")]
    @muchv2,

    [Description("Opus")]
    @opus,

    [Description("Satin")]
    @satin,

    [Description("SatinFullband")]
    @satinFullband,

    [Description("RtAudio8")]
    @rtAudio8,

    [Description("RtAudio16")]
    @rtAudio16,

    [Description("Silk")]
    @silk,

    [Description("SilkNarrow")]
    @silkNarrow,

    [Description("SilkWide")]
    @silkWide,

    [Description("Siren")]
    @siren,

    [Description("XmsRta")]
    @xmsRta,
}
