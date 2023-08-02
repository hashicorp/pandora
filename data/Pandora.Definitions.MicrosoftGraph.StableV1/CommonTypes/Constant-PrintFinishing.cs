// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrintFinishingConstant
{
    [Description("None")]
    @none,

    [Description("Staple")]
    @staple,

    [Description("Punch")]
    @punch,

    [Description("Cover")]
    @cover,

    [Description("Bind")]
    @bind,

    [Description("SaddleStitch")]
    @saddleStitch,

    [Description("StitchEdge")]
    @stitchEdge,

    [Description("StapleTopLeft")]
    @stapleTopLeft,

    [Description("StapleBottomLeft")]
    @stapleBottomLeft,

    [Description("StapleTopRight")]
    @stapleTopRight,

    [Description("StapleBottomRight")]
    @stapleBottomRight,

    [Description("StitchLeftEdge")]
    @stitchLeftEdge,

    [Description("StitchTopEdge")]
    @stitchTopEdge,

    [Description("StitchRightEdge")]
    @stitchRightEdge,

    [Description("StitchBottomEdge")]
    @stitchBottomEdge,

    [Description("StapleDualLeft")]
    @stapleDualLeft,

    [Description("StapleDualTop")]
    @stapleDualTop,

    [Description("StapleDualRight")]
    @stapleDualRight,

    [Description("StapleDualBottom")]
    @stapleDualBottom,
}
