// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallRecordsMediaStreamVideoCodecConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Invalid")]
    @invalid,

    [Description("Av1")]
    @av1,

    [Description("H263")]
    @h263,

    [Description("H264")]
    @h264,

    [Description("H264s")]
    @h264s,

    [Description("H264uc")]
    @h264uc,

    [Description("H265")]
    @h265,

    [Description("Rtvc1")]
    @rtvc1,

    [Description("RtVideo")]
    @rtVideo,

    [Description("Xrtvc1")]
    @xrtvc1,
}
