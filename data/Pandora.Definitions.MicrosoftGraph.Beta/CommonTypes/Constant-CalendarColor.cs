// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CalendarColorConstant
{
    [Description("Auto")]
    @auto,

    [Description("LightBlue")]
    @lightBlue,

    [Description("LightGreen")]
    @lightGreen,

    [Description("LightOrange")]
    @lightOrange,

    [Description("LightGray")]
    @lightGray,

    [Description("LightYellow")]
    @lightYellow,

    [Description("LightTeal")]
    @lightTeal,

    [Description("LightPink")]
    @lightPink,

    [Description("LightBrown")]
    @lightBrown,

    [Description("LightRed")]
    @lightRed,

    [Description("MaxColor")]
    @maxColor,
}
